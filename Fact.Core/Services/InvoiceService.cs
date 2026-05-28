using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Fact.Core.Models;

namespace Fact.Core.Services;

public interface IInvoiceService
{
    InvoiceResponse Generate(InvoiceRequest request);
    InvoiceResponse GenerateAndSign(InvoiceRequest request, X509Certificate2 certificate);
    Task<InvoiceResponse> GenerateSignAndSend(InvoiceRequest request, X509Certificate2 certificate);
}

public class InvoiceService : IInvoiceService
{
    private readonly IXmlGeneratorService _xmlGenerator;
    private readonly ISignatureService _signatureService;
    private readonly ISunatSenderService _sunatSender;

    public InvoiceService(
        IXmlGeneratorService xmlGenerator,
        ISignatureService signatureService,
        ISunatSenderService sunatSender)
    {
        _xmlGenerator = xmlGenerator;
        _signatureService = signatureService;
        _sunatSender = sunatSender;
    }

    public InvoiceResponse Generate(InvoiceRequest request)
    {
        try
        {
            var doc = _xmlGenerator.GenerateInvoice(request);
            var xmlString = doc.ToString(SaveOptions.DisableFormatting);
            return BuildResponse(xmlString, "XML generado correctamente", null);
        }
        catch (Exception ex)
        {
            return new InvoiceResponse
            {
                Exitoso = false,
                Mensaje = $"Error al generar XML: {ex.Message}"
            };
        }
    }

    public InvoiceResponse GenerateAndSign(
        InvoiceRequest request, X509Certificate2 certificate)
    {
        try
        {
            var doc = _xmlGenerator.GenerateInvoice(request);
            var xmlString = doc.ToString(SaveOptions.DisableFormatting);
            var signedXml = _signatureService.SignXml(xmlString, certificate);
            return BuildResponse(signedXml, "XML generado y firmado correctamente", certificate);
        }
        catch (Exception ex)
        {
            return new InvoiceResponse
            {
                Exitoso = false,
                Mensaje = $"Error al generar/firmar XML: {ex.Message}"
            };
        }
    }

    public async Task<InvoiceResponse> GenerateSignAndSend(
        InvoiceRequest request, X509Certificate2 certificate)
    {
        try
        {
            var doc = _xmlGenerator.GenerateInvoice(request);
            var xmlString = doc.ToString(SaveOptions.DisableFormatting);
            var signedXml = _signatureService.SignXml(xmlString, certificate);

            var sunatResponse = await _sunatSender.SendInvoice(signedXml);

            var result = BuildResponse(signedXml,
                sunatResponse.Exitoso
                    ? "Factura enviada y aceptada por SUNAT"
                    : $"Factura generada pero rechazada por SUNAT: {sunatResponse.Descripcion}",
                certificate);
            result.EnvioSunat = sunatResponse;
            return result;
        }
        catch (Exception ex)
        {
            return new InvoiceResponse
            {
                Exitoso = false,
                Mensaje = $"Error al generar/firmar/enviar XML: {ex.Message}"
            };
        }
    }

    private static InvoiceResponse BuildResponse(
        string xmlString, string mensaje, X509Certificate2? certificate)
    {
        var xmlBase64 = Convert.ToBase64String(
            System.Text.Encoding.UTF8.GetBytes(xmlString));

        var serieNumero = ExtractSerieNumero(xmlString);

        return new InvoiceResponse
        {
            Exitoso = true,
            Mensaje = mensaje,
            XmlFirmado = xmlString,
            XmlBase64 = xmlBase64,
            SerieNumero = serieNumero,
            HashFirma = certificate != null
                ? Convert.ToBase64String(certificate.GetCertHash()) : null
        };
    }

    private static string ExtractSerieNumero(string xml)
    {
        try
        {
            var doc = XDocument.Parse(xml);
            var cbc = XNamespace.Get("urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            return doc.Descendants(cbc + "ID").FirstOrDefault()?.Value ?? "";
        }
        catch
        {
            return "";
        }
    }
}
