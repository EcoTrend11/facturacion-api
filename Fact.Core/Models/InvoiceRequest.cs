using System.Text.Json.Serialization;

namespace Fact.Core.Models;

public class InvoiceRequest
{
    public string Serie { get; set; } = "";
    public int Numero { get; set; }
    public string FechaEmision { get; set; } = "";
    public string HoraEmision { get; set; } = "";
    public string? FechaVencimiento { get; set; }
    public string TipoOperacion { get; set; } = "0101";
    public string Moneda { get; set; } = "PEN";
    public string? OrdenCompra { get; set; }
    public string FormaPago { get; set; } = "Contado";

    public Emisor Emisor { get; set; } = new();
    public Adquirente Adquirente { get; set; } = new();
    public DireccionEntrega? Entrega { get; set; }

    public List<DocumentoReferencia> GuiasRemision { get; set; } = [];
    public List<DocumentoReferencia> DocumentosRelacionados { get; set; } = [];
    public List<Leyenda> Leyendas { get; set; } = [];
    public List<ImpuestoGlobal> Impuestos { get; set; } = [];
    public List<DescuentoCargo> DescuentosGlobales { get; set; } = [];
    public List<DescuentoCargo> CargosGlobales { get; set; } = [];
    public List<Anticipo> Anticipos { get; set; } = [];

    public List<ItemFactura> Items { get; set; } = [];

    public Detraccion? Detraccion { get; set; }
    public Percepcion? Percepcion { get; set; }
}

public class Emisor
{
    public string Ruc { get; set; } = "";
    public string RazonSocial { get; set; } = "";
    public string? NombreComercial { get; set; }
    public string CodigoDomicilioFiscal { get; set; } = "0000";
}

public class Adquirente
{
    public string TipoDocumento { get; set; } = "6";
    public string NumeroDocumento { get; set; } = "";
    public string RazonSocial { get; set; } = "";
}

public class DireccionEntrega
{
    public string? Direccion { get; set; }
    public string? Provincia { get; set; }
    public string? Departamento { get; set; }
    public string? Distrito { get; set; }
    public string? Ubigeo { get; set; }
    public string? CodigoPais { get; set; } = "PE";
}

public class DocumentoReferencia
{
    public string TipoDocumento { get; set; } = "";
    public string Numero { get; set; } = "";
}

public class Leyenda
{
    public string Codigo { get; set; } = "";
    public string? Texto { get; set; }
}

public class ImpuestoGlobal
{
    public string Id { get; set; } = "1000";
    public string Nombre { get; set; } = "IGV";
    public string CodigoInternacional { get; set; } = "VAT";
    public string Categoria { get; set; } = "S";
    public decimal MontoBase { get; set; }
    public decimal Monto { get; set; }
}

public class DescuentoCargo
{
    public bool Indicador { get; set; }
    public string CodigoMotivo { get; set; } = "00";
    public decimal? Factor { get; set; }
    public decimal Monto { get; set; }
    public decimal Base { get; set; }
}

public class Anticipo
{
    public string TipoDocumento { get; set; } = "";
    public string Numero { get; set; } = "";
    public decimal Monto { get; set; }
    public string Moneda { get; set; } = "PEN";
    public string? RucEmisor { get; set; }
}

public class ItemFactura
{
    public int NumeroOrden { get; set; }
    public decimal Cantidad { get; set; }
    public string UnidadMedida { get; set; } = "NIU";
    public string Descripcion { get; set; } = "";
    public string? CodigoProducto { get; set; }
    public string? CodigoProductoSunat { get; set; }
    public decimal ValorUnitario { get; set; }
    public decimal PrecioVentaUnitario { get; set; }
    public string TipoPrecio { get; set; } = "01";
    public decimal ValorVenta { get; set; }
    public string AfectacionIgv { get; set; } = "10";
    public decimal Igv { get; set; }
    public decimal PorcentajeIgv { get; set; } = 18.00m;
    public IscInfo? Isc { get; set; }

    public List<DescuentoCargo> Descuentos { get; set; } = [];
    public List<DescuentoCargo> Cargos { get; set; } = [];
    public List<PropiedadAdicional> PropiedadesAdicionales { get; set; } = [];
}

public class IscInfo
{
    public decimal Monto { get; set; }
    public string Sistema { get; set; } = "01";
    public decimal Porcentaje { get; set; }
}

public class PropiedadAdicional
{
    public string Codigo { get; set; } = "";
    public string Nombre { get; set; } = "";
    public string? Valor { get; set; }
    public string? FechaInicio { get; set; }
    public string? FechaFin { get; set; }
    public int? Duracion { get; set; }
}

public class Detraccion
{
    public string CodigoBien { get; set; } = "";
    public decimal Porcentaje { get; set; }
    public decimal Monto { get; set; }
    public string? CuentaBancoNacion { get; set; }
}

public class Percepcion
{
    public decimal Tasa { get; set; }
    public decimal Monto { get; set; }
}
