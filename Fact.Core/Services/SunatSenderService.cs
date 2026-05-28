using System.IO.Compression;
using System.Xml.Linq;
using Fact.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Fact.Core.Services;

public interface ISunatSenderService
{
    Task<SunatResponse> SendInvoice(string signedXml, string? fileName = null);
}

public class SunatSenderService : ISunatSenderService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<SunatSenderService> _logger;
    private readonly string _ruc;
    private readonly string _usuario;
    private readonly string _password;

    public SunatSenderService(
        HttpClient httpClient,
        IConfiguration configuration,
        ILogger<SunatSenderService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _ruc = configuration["Sunat:Ruc"] ?? "";
        _usuario = configuration["Sunat:Usuario"] ?? "MODDATOS";
        _password = configuration["Sunat:Password"] ?? "moddatos";
    }

    public async Task<SunatResponse> SendInvoice(string signedXml, string? fileName = null)
    {
        try
        {
            var zipB64 = CreateZipWithXml(signedXml, out var zipFileName);
            fileName ??= zipFileName;

            var soapEnvelope = BuildSoapEnvelope(fileName, zipB64);
            var content = new StringContent(soapEnvelope, System.Text.Encoding.UTF8, "text/xml");
            content.Headers.Add("SOAPAction", "urn:sendBill");

            _logger.LogInformation("Enviando a SUNAT: {FileName}, ZIP size: {Size} bytes",
                fileName, Convert.FromBase64String(zipB64).Length);

            var response = await _httpClient.PostAsync("", content);
            var responseBody = await response.Content.ReadAsStringAsync();

            _logger.LogInformation("Respuesta SUNAT recibida ({Length} chars)", responseBody.Length);

            return ParseSoapResponse(responseBody);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error de conexión con SUNAT");
            return new SunatResponse
            {
                Exitoso = false,
                Descripcion = $"Error de conexión: {ex.Message}"
            };
        }
    }

    private static string CreateZipWithXml(string signedXml, out string fileName)
    {
        var docType = "01";
        var serie = "F001";
        var numero = "1";
        var ruc = "";

        // Extract data from XML
        var doc = XDocument.Parse(signedXml);
        var cbc = XNamespace.Get("urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
        var cac = XNamespace.Get("urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");

        var idEl = doc.Descendants(cbc + "ID").FirstOrDefault();
        if (idEl?.Value != null)
        {
            var parts = idEl.Value.Split('-');
            if (parts.Length == 2) { serie = parts[0]; numero = parts[1]; }
        }

        var partyId = doc.Descendants(cac + "AccountingSupplierParty")
            .Descendants(cac + "PartyIdentification")
            .Descendants(cbc + "ID").FirstOrDefault();
        if (partyId?.Value != null) ruc = partyId.Value;

        fileName = $"{ruc}-{docType}-{serie}-{numero}.zip";

        using var ms = new MemoryStream();
        using (var zip = new ZipArchive(ms, ZipArchiveMode.Create, true))
        {
            var entryName = $"{ruc}-{docType}-{serie}-{numero}.xml";
            var entry = zip.CreateEntry(entryName, CompressionLevel.Optimal);
            using var writer = new StreamWriter(entry.Open());
            writer.Write(signedXml);
        }

        return Convert.ToBase64String(ms.ToArray());
    }

    private string BuildSoapEnvelope(string fileName, string zipBase64)
    {
        return $@"<?xml version=""1.0"" encoding=""utf-8""?>
<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""
                  xmlns:ser=""http://service.sunat.gob.pe""
                  xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
   <soapenv:Header>
      <wsse:Security>
         <wsse:UsernameToken>
            <wsse:Username>{_ruc}{_usuario}</wsse:Username>
            <wsse:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">{_password}</wsse:Password>
         </wsse:UsernameToken>
      </wsse:Security>
   </soapenv:Header>
   <soapenv:Body>
      <ser:sendBill>
         <fileName>{fileName}</fileName>
         <contentFile>{zipBase64}</contentFile>
      </ser:sendBill>
   </soapenv:Body>
</soapenv:Envelope>";
    }

    private SunatResponse ParseSoapResponse(string responseBody)
    {
        try
        {
            var xml = XDocument.Parse(responseBody);

            // Check for SOAP Fault first
            var fault = xml.Descendants().FirstOrDefault(e =>
                e.Name.LocalName == "faultstring" ||
                e.Name.LocalName == "Fault");
            if (fault != null)
            {
                _logger.LogWarning("SOAP Fault recibido de SUNAT");

                var faultCode = xml.Descendants().FirstOrDefault(e =>
                    e.Name.LocalName == "faultcode")?.Value;
                var faultString = xml.Descendants().FirstOrDefault(e =>
                    e.Name.LocalName == "faultstring")?.Value;

                _logger.LogWarning("FaultCode: {Code}, FaultString: {String}",
                    faultCode, faultString);

                return new SunatResponse
                {
                    Exitoso = false,
                    Codigo = faultCode,
                    Descripcion = $"Error SOAP: {faultString ?? faultCode ?? "Error desconocido"}"
                };
            }

            var ns = XNamespace.Get("http://service.sunat.gob.pe");

            var status = xml.Descendants(ns + "status").FirstOrDefault()?.Value
                ?? xml.Descendants().FirstOrDefault(e => e.Name.LocalName == "status")?.Value;
            var applicationResponseB64 = xml.Descendants(ns + "applicationResponse").FirstOrDefault()?.Value
                ?? xml.Descendants().FirstOrDefault(e => e.Name.LocalName == "applicationResponse")?.Value;

            var isSuccess = status == "0";
            string? descripcion = null;
            string? cdrBase64 = null;
            string? numeroCdr = null;

            // Intenta extraer el CDR desde applicationResponse (base64 -> zip -> xml)
            if (!string.IsNullOrEmpty(applicationResponseB64))
            {
                cdrBase64 = applicationResponseB64;
                try
                {
                    var cdrBytes = Convert.FromBase64String(applicationResponseB64);
                    using var ms = new MemoryStream(cdrBytes);
                    using var zip = new ZipArchive(ms, ZipArchiveMode.Read);
                    var entry = zip.Entries.FirstOrDefault(e => e.Name.EndsWith(".xml"));
                    if (entry != null)
                    {
                        using var reader = new StreamReader(entry.Open());
                        var cdrXml = reader.ReadToEnd();
                        ParseCdr(cdrXml, out descripcion, out numeroCdr, out var cdrCodigo);
                        if (cdrCodigo == "0") { status = "0"; isSuccess = true; }
                        else if (!isSuccess && cdrCodigo != null) status = cdrCodigo;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Error al descomprimir CDR de SUNAT");
                }
            }

            descripcion ??= isSuccess ? "Aceptado" : $"Rechazado (código: {status})";

            return new SunatResponse
            {
                Exitoso = isSuccess,
                Codigo = status,
                Descripcion = descripcion,
                NumeroCdr = numeroCdr,
                CdrBase64 = cdrBase64
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al parsear respuesta SOAP de SUNAT");
            return new SunatResponse
            {
                Exitoso = false,
                Descripcion = $"Error al parsear respuesta de SUNAT: {ex.Message}"
            };
        }
    }

    private static void ParseCdr(string cdrXml, out string? descripcion, out string? numeroCdr, out string? codigo)
    {
        descripcion = null;
        numeroCdr = null;
        codigo = null;

        try
        {
            var cdr = XDocument.Parse(cdrXml);
            var cac = XNamespace.Get("urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            var cbc = XNamespace.Get("urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");

            var documentResponse = cdr.Descendants(cac + "DocumentResponse").FirstOrDefault();
            if (documentResponse != null)
            {
                var response = documentResponse.Element(cac + "Response");
                if (response != null)
                {
                    codigo = response.Element(cbc + "ResponseCode")?.Value;
                    descripcion = response.Element(cbc + "Description")?.Value;
                }
            }

            var notes = cdr.Descendants(cbc + "Note")
                .Select(n => n.Value)
                .Where(n => !string.IsNullOrEmpty(n))
                .ToList();

            if (notes.Count > 0)
            {
                var obs = string.Join(" | ", notes);
                descripcion = descripcion != null ? $"{descripcion} — {obs}" : obs;
            }

            var id = cdr.Descendants(cbc + "ID").FirstOrDefault()?.Value;
            if (!string.IsNullOrEmpty(id))
                numeroCdr = id;
        }
        catch
        {
            // No se pudo parsear el CDR, usar valores por defecto
        }
    }
}
