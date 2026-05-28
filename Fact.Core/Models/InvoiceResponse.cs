namespace Fact.Core.Models;

public class InvoiceResponse
{
    public bool Exitoso { get; set; }
    public string Mensaje { get; set; } = "";
    public string? XmlFirmado { get; set; }
    public string? XmlBase64 { get; set; }
    public string? SerieNumero { get; set; }
    public string? HashFirma { get; set; }
    public SunatResponse? EnvioSunat { get; set; }
}

public class SunatResponse
{
    public bool Exitoso { get; set; }
    public string? Codigo { get; set; }
    public string? Descripcion { get; set; }
    public string? NumeroCdr { get; set; }
    public string? CdrBase64 { get; set; }
}
