using Fact.Core.Models;
using Fact.Core.Services;

namespace Fact.Tests;

public class XmlGeneratorTests
{
    private readonly XmlGeneratorService _generator;
    private readonly CatalogService _catalog;

    public XmlGeneratorTests()
    {
        _catalog = new CatalogService();
        _generator = new XmlGeneratorService(_catalog);
    }

    [Fact]
    public void GenerateInvoice_BasicInvoice_ReturnsValidXml()
    {
        var request = new InvoiceRequest
        {
            Serie = "F001",
            Numero = 1,
            FechaEmision = "2026-05-27",
            HoraEmision = "14:30:00",
            TipoOperacion = "0101",
            Moneda = "PEN",
            Emisor = new Emisor
            {
                Ruc = "20000000001",
                RazonSocial = "GREEN SAC",
                NombreComercial = "GREEN",
                CodigoDomicilioFiscal = "0001"
            },
            Adquirente = new Adquirente
            {
                TipoDocumento = "6",
                NumeroDocumento = "20102420706",
                RazonSocial = "CECI FARMA IMPORT S.R.L."
            },
            Items =
            [
                new ItemFactura
                {
                    NumeroOrden = 1,
                    Cantidad = 50,
                    UnidadMedida = "CS",
                    Descripcion = "CAPTOPRIL 1000mg X 30",
                    CodigoProducto = "Cap-258963",
                    CodigoProductoSunat = "51121703",
                    ValorUnitario = 28.7896m,
                    PrecioVentaUnitario = 34.99m,
                    TipoPrecio = "01",
                    ValorVenta = 1439.48m,
                    AfectacionIgv = "10",
                    Igv = 259.11m,
                    PorcentajeIgv = 18.00m
                }
            ]
        };

        var doc = _generator.GenerateInvoice(request);
        var xml = doc.ToString();

        Assert.Contains("<cbc:UBLVersionID>2.1</cbc:UBLVersionID>", xml);
        Assert.Contains("<cbc:ID>F001-1</cbc:ID>", xml);
        Assert.Contains("<cbc:RegistrationName>GREEN SAC</cbc:RegistrationName>", xml);
        Assert.Contains("20000000001", xml);
        Assert.Contains("CAPTOPRIL 1000mg X 30", xml);
        Assert.Contains("1439.48", xml);
        Assert.Contains("259.11", xml);
    }

    [Fact]
    public void GenerateInvoice_WithIgvAndIsc_IncludesBothTaxes()
    {
        var request = new InvoiceRequest
        {
            Serie = "F001",
            Numero = 2,
            FechaEmision = "2026-05-27",
            HoraEmision = "14:30:00",
            Moneda = "PEN",
            Emisor = new Emisor { Ruc = "20000000001", RazonSocial = "Test S.A." },
            Adquirente = new Adquirente { TipoDocumento = "6", NumeroDocumento = "20587896411", RazonSocial = "Cliente S.A." },
            Items =
            [
                new ItemFactura
                {
                    NumeroOrden = 1,
                    Cantidad = 2000,
                    UnidadMedida = "BX",
                    Descripcion = "Cerveza Clásica x 12",
                    ValorUnitario = 21.92m,
                    PrecioVentaUnitario = 38.00m,
                    TipoPrecio = "01",
                    ValorVenta = 35067.82m,
                    AfectacionIgv = "10",
                    Igv = 10015.17m,
                    PorcentajeIgv = 18.00m,
                    Isc = new IscInfo { Monto = 20572.00m, Sistema = "03", Porcentaje = 27.8m }
                }
            ]
        };

        var doc = _generator.GenerateInvoice(request);
        var xml = doc.ToString();

        Assert.Contains("2000", xml);
        Assert.Contains("BX", xml);
        Assert.Contains("Cerveza", xml);
        Assert.Contains("1000", xml);      // IGV code
        Assert.Contains("2000", xml);      // ISC code
    }
}
