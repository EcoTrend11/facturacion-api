using System.Security.Cryptography.X509Certificates;
using Fact.Core.Models;
using Fact.Core.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Fact.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;
    private readonly IValidator<InvoiceRequest> _validator;
    private readonly ILogger<InvoiceController> _logger;
    private readonly X509Certificate2 _signingCert;

    public InvoiceController(
        IInvoiceService invoiceService,
        IValidator<InvoiceRequest> validator,
        ILogger<InvoiceController> logger,
        IConfiguration configuration)
    {
        _invoiceService = invoiceService;
        _validator = validator;
        _logger = logger;

        var certPath = configuration["Certificate:Path"] ?? "../certs/test-cert.pfx";
        var certPassword = configuration["Certificate:Password"] ?? "12345";

        var fullPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppContext.BaseDirectory, certPath));
        if (!System.IO.File.Exists(fullPath))
        {
            fullPath = System.IO.Path.GetFullPath(certPath);
        }
        if (!System.IO.File.Exists(fullPath))
        {
            fullPath = System.IO.Path.GetFullPath(System.IO.Path.Combine(Directory.GetCurrentDirectory(), certPath));
        }

        _signingCert = new X509Certificate2(fullPath, certPassword, X509KeyStorageFlags.Exportable);
        _logger.LogInformation("Certificado cargado desde: {Path}", fullPath);
    }

    [HttpPost("generate-xml")]
    public IActionResult GenerateXml([FromBody] InvoiceRequest request)
    {
        var result = _invoiceService.Generate(request);
        if (!result.Exitoso)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("generate-signed")]
    public IActionResult GenerateSigned([FromBody] InvoiceRequest request)
    {
        var result = _invoiceService.GenerateAndSign(request, _signingCert);
        if (!result.Exitoso)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("send")]
    public async Task<IActionResult> Send([FromBody] InvoiceRequest request)
    {
        var result = await _invoiceService.GenerateSignAndSend(request, _signingCert);

        if (!result.Exitoso)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("validate")]
    public async Task<IActionResult> ValidateData([FromBody] InvoiceRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .Select(e => $"[{e.PropertyName}] {e.ErrorMessage}");

            return BadRequest(new InvoiceResponse
            {
                Exitoso = false,
                Mensaje = $"Errores de validación: {string.Join("; ", errors)}"
            });
        }

        return Ok(new InvoiceResponse
        {
            Exitoso = true,
            Mensaje = "Datos válidos"
        });
    }

}
