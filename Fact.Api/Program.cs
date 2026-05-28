using System.Reflection;
using Fact.Api.Middleware;
using Fact.Core.Services;
using Fact.Core.Validators;
using FluentValidation;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        opts.JsonSerializerOptions.PropertyNamingPolicy =
            System.Text.Json.JsonNamingPolicy.CamelCase;
        opts.JsonSerializerOptions.DefaultIgnoreCondition =
            System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{
    opts.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Fact - API de Facturación Electrónica SUNAT",
        Version = "v1",
        Description = "API REST para generar, firmar digitalmente y enviar facturas electrónicas (UBL 2.1) al SUNAT OSE."
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
        opts.IncludeXmlComments(xmlPath);
});

builder.Services.AddValidatorsFromAssemblyContaining<InvoiceRequestValidator>();

builder.Services.AddSingleton<ICatalogService, CatalogService>();
builder.Services.AddSingleton<IXmlGeneratorService, XmlGeneratorService>();
builder.Services.AddSingleton<ISignatureService, SignatureService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();

builder.Services.AddHttpClient<ISunatSenderService, SunatSenderService>(client =>
{
    client.BaseAddress = new Uri(
        builder.Configuration["Sunat:OseUrl"]
        ?? "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService");
    client.Timeout = TimeSpan.FromSeconds(60);
});

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS se maneja en el reverse proxy; no se requiere dentro del container
app.UseAuthorization();
app.MapControllers();

app.Run();
