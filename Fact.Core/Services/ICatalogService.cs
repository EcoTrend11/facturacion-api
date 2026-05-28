using Fact.Core.Models;

namespace Fact.Core.Services;

public interface ICatalogService
{
    Dictionary<string, string> GetCatalogo01();
    Dictionary<string, string> GetCatalogo03();
    SunatTaxEntry? GetTributo(string id);
    string GetCategoriaTributo(string id);
    Dictionary<string, string> GetCatalogo06();
    Dictionary<string, string> GetCatalogo07();
    Dictionary<string, string> GetCatalogo08();
    Dictionary<string, string> GetCatalogo12();
    Dictionary<string, string> GetCatalogo16();
    Dictionary<string, string> GetCatalogo51();
    Dictionary<string, string> GetCatalogo52();
    SunatChargeDiscountEntry? GetCargoDescuento(string codigo);
}
