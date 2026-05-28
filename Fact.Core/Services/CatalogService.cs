using System.Reflection;
using System.Text.Json;
using Fact.Core.Models;

namespace Fact.Core.Services;

public class CatalogService : ICatalogService
{
    private readonly Dictionary<string, SunatTaxEntry> _tributos;
    private readonly Dictionary<string, string> _catalogo01;
    private readonly Dictionary<string, string> _catalogo03;
    private readonly Dictionary<string, string> _catalogo06;
    private readonly Dictionary<string, string> _catalogo07;
    private readonly Dictionary<string, string> _catalogo08;
    private readonly Dictionary<string, string> _catalogo12;
    private readonly Dictionary<string, string> _catalogo16;
    private readonly Dictionary<string, string> _catalogo51;
    private readonly Dictionary<string, string> _catalogo52;
    private readonly Dictionary<string, SunatChargeDiscountEntry> _catalogo53;

    public CatalogService()
    {
        _tributos = LoadList<SunatTaxEntry>("catalogo05.json").ToDictionary(x => x.Id);
        _catalogo01 = LoadCatalog("catalogo01.json");
        _catalogo03 = LoadCatalog("catalogo03.json");
        _catalogo06 = LoadCatalog("catalogo06.json");
        _catalogo07 = LoadCatalog("catalogo07.json");
        _catalogo08 = LoadCatalog("catalogo08.json");
        _catalogo12 = LoadCatalog("catalogo12.json");
        _catalogo16 = LoadCatalog("catalogo16.json");
        _catalogo51 = LoadCatalog("catalogo51.json");
        _catalogo52 = LoadCatalog("catalogo52.json");
        _catalogo53 = LoadList<SunatChargeDiscountEntry>("catalogo53.json").ToDictionary(x => x.Codigo);
    }

    public Dictionary<string, string> GetCatalogo01() => _catalogo01;
    public Dictionary<string, string> GetCatalogo03() => _catalogo03;
    public Dictionary<string, string> GetCatalogo06() => _catalogo06;
    public Dictionary<string, string> GetCatalogo07() => _catalogo07;
    public Dictionary<string, string> GetCatalogo08() => _catalogo08;
    public Dictionary<string, string> GetCatalogo12() => _catalogo12;
    public Dictionary<string, string> GetCatalogo16() => _catalogo16;
    public Dictionary<string, string> GetCatalogo51() => _catalogo51;
    public Dictionary<string, string> GetCatalogo52() => _catalogo52;
    public SunatTaxEntry? GetTributo(string id) => _tributos.GetValueOrDefault(id);
    public string GetCategoriaTributo(string id) => _tributos.GetValueOrDefault(id)?.Categoria ?? "S";
    public SunatChargeDiscountEntry? GetCargoDescuento(string codigo) => _catalogo53.GetValueOrDefault(codigo);

    private static Dictionary<string, string> LoadCatalog(string filename)
    {
        var path = Path.Combine(GetCatalogsPath(), filename);
        var json = File.ReadAllText(path);
        var entries = JsonSerializer.Deserialize<List<SunatCatalogEntry>>(json) ?? [];
        return entries.ToDictionary(x => x.Codigo, x => x.Descripcion);
    }

    private static List<T> LoadList<T>(string filename)
    {
        var path = Path.Combine(GetCatalogsPath(), filename);
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<T>>(json) ?? [];
    }

    private static string GetCatalogsPath()
    {
        var assemblyDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? ".";
        var baseDir = Directory.Exists(Path.Combine(assemblyDir, "Catalogs", "json"))
            ? assemblyDir
            : AppDomain.CurrentDomain.BaseDirectory;
        var path = Path.Combine(baseDir, "Catalogs", "json");
        if (!Directory.Exists(path))
        {
            path = Path.Combine(AppContext.BaseDirectory, "Catalogs", "json");
        }
        if (!Directory.Exists(path))
        {
            var projectDir = Directory.GetCurrentDirectory();
            path = Path.Combine(projectDir, "..", "Fact.Core", "Catalogs", "json");
        }
        if (!Directory.Exists(path))
        {
            path = Path.Combine(Directory.GetCurrentDirectory(), "Catalogs", "json");
        }
        return path;
    }
}
