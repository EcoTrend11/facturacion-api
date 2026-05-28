using System.Text.Json.Serialization;

namespace Fact.Core.Models;

public class SunatCatalogEntry
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = "";

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; } = "";
}

public class SunatTaxEntry
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = "";

    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = "";

    [JsonPropertyName("tipoCodigo")]
    public string TipoCodigo { get; set; } = "";

    [JsonPropertyName("categoria")]
    public string Categoria { get; set; } = "";
}

public class SunatChargeDiscountEntry
{
    [JsonPropertyName("codigo")]
    public string Codigo { get; set; } = "";

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; } = "";

    [JsonPropertyName("chargeIndicator")]
    public bool ChargeIndicator { get; set; }

    [JsonPropertyName("factor")]
    public decimal? Factor { get; set; }
}
