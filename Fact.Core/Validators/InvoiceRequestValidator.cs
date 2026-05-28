using Fact.Core.Models;
using Fact.Core.Services;
using FluentValidation;

namespace Fact.Core.Validators;

public class InvoiceRequestValidator : AbstractValidator<InvoiceRequest>
{
    private static readonly string[] _tiposOperacionValidos =
        ["0101", "0102", "0103", "0104", "0105", "0110", "0111", "0112", "0113", "0114"];

    public InvoiceRequestValidator(ICatalogService catalog)
    {
        var cat01 = catalog.GetCatalogo01();
        var cat03 = catalog.GetCatalogo03();
        var cat06 = catalog.GetCatalogo06();
        var cat07 = catalog.GetCatalogo07();
        var cat16 = catalog.GetCatalogo16();
        var cat51 = catalog.GetCatalogo51();
        var cat52 = catalog.GetCatalogo52();

        RuleFor(r => r.Serie)
            .NotEmpty().WithMessage("La serie es obligatoria")
            .Matches(@"^[A-Za-z0-9]{4,8}$").WithMessage("La serie debe tener entre 4 y 8 caracteres alfanuméricos");

        RuleFor(r => r.Numero)
            .GreaterThan(0).WithMessage("El número debe ser mayor a 0");

        RuleFor(r => r.FechaEmision)
            .NotEmpty().WithMessage("La fecha de emisión es obligatoria")
            .Matches(@"^\d{4}-\d{2}-\d{2}$").WithMessage("La fecha debe tener formato yyyy-MM-dd");

        RuleFor(r => r.HoraEmision)
            .NotEmpty().WithMessage("La hora de emisión es obligatoria")
            .Matches(@"^\d{2}:\d{2}:\d{2}$").WithMessage("La hora debe tener formato HH:mm:ss");

        RuleFor(r => r.Moneda)
            .NotEmpty().WithMessage("La moneda es obligatoria")
            .Length(3).WithMessage("La moneda debe ser un código de 3 caracteres (ISO 4217)");

        RuleFor(r => r.TipoOperacion)
            .NotEmpty().WithMessage("El tipo de operación es obligatorio")
            .Must(id => _tiposOperacionValidos.Contains(id))
            .WithMessage("El tipo de operación '{PropertyValue}' no es válido. Use: " + string.Join(", ", _tiposOperacionValidos));

        RuleFor(r => r.OrdenCompra)
            .MaximumLength(100).WithMessage("La orden de compra no puede exceder 100 caracteres")
            .When(r => !string.IsNullOrEmpty(r.OrdenCompra));

        RuleFor(r => r.Emisor).NotNull().WithMessage("Los datos del emisor son obligatorios");
        RuleFor(r => r.Adquirente).NotNull().WithMessage("Los datos del adquirente son obligatorios");

        When(r => r.Emisor != null, () =>
        {
            RuleFor(r => r.Emisor!.Ruc)
                .NotEmpty().WithMessage("El RUC del emisor es obligatorio")
                .Length(11).WithMessage("El RUC debe tener 11 dígitos")
                .Matches(@"^\d{11}$").WithMessage("El RUC debe contener solo dígitos");

            RuleFor(r => r.Emisor!.RazonSocial)
                .NotEmpty().WithMessage("La razón social del emisor es obligatoria")
                .MaximumLength(200).WithMessage("La razón social no puede exceder 200 caracteres");

            RuleFor(r => r.Emisor!.CodigoDomicilioFiscal)
                .NotEmpty().WithMessage("El código de domicilio fiscal es obligatorio")
                .Length(4).WithMessage("El código de domicilio fiscal debe tener 4 dígitos")
                .Matches(@"^\d{4}$").WithMessage("El código de domicilio fiscal debe contener solo dígitos");
        });

        When(r => r.Adquirente != null, () =>
        {
            RuleFor(r => r.Adquirente!.TipoDocumento)
                .NotEmpty().WithMessage("El tipo de documento del adquirente es obligatorio")
                .Must(id => cat06.ContainsKey(id))
                .WithMessage("El tipo de documento '{PropertyValue}' no es válido (use: 6=RUC, 1=DNI, 7=Pasaporte, etc.)");

            RuleFor(r => r.Adquirente!.NumeroDocumento)
                .NotEmpty().WithMessage("El número de documento del adquirente es obligatorio")
                .MaximumLength(20).WithMessage("El documento no puede exceder 20 caracteres");

            RuleFor(r => r.Adquirente!.RazonSocial)
                .NotEmpty().WithMessage("La razón social del adquirente es obligatoria")
                .MaximumLength(200).WithMessage("La razón social no puede exceder 200 caracteres");
        });

        RuleFor(r => r.Impuestos)
            .Must(taxes => taxes.Count <= 10)
            .WithMessage("No puede haber más de 10 impuestos globales")
            .When(r => r.Impuestos is { Count: > 0 });

        RuleFor(r => r.Items)
            .NotEmpty().WithMessage("Debe haber al menos un ítem");

        RuleForEach(r => r.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.NumeroOrden)
                .GreaterThan(0).WithMessage("El número de orden debe ser mayor a 0");

            item.RuleFor(i => i.Cantidad)
                .GreaterThan(0).WithMessage("La cantidad debe ser mayor a 0");

            item.RuleFor(i => i.UnidadMedida)
                .NotEmpty().WithMessage("La unidad de medida es obligatoria")
                .Must(id => cat03.ContainsKey(id))
                .WithMessage("La unidad de medida '{PropertyValue}' no es válida");

            item.RuleFor(i => i.Descripcion)
                .NotEmpty().WithMessage("La descripción del ítem es obligatoria")
                .MaximumLength(500).WithMessage("La descripción no puede exceder 500 caracteres");

            item.RuleFor(i => i.CodigoProductoSunat)
                .Must(id => string.IsNullOrEmpty(id) || cat06.ContainsKey(id))
                .WithMessage("El código de producto SUNAT '{PropertyValue}' no es válido");

            item.RuleFor(i => i.ValorUnitario)
                .GreaterThanOrEqualTo(0).WithMessage("El valor unitario no puede ser negativo");

            item.RuleFor(i => i.PrecioVentaUnitario)
                .GreaterThanOrEqualTo(0).WithMessage("El precio de venta unitario no puede ser negativo");

            item.RuleFor(i => i.TipoPrecio)
                .NotEmpty().WithMessage("El tipo de precio es obligatorio")
                .Must(id => new[] { "01", "02" }.Contains(id))
                .WithMessage("El tipo de precio debe ser '01' (precio unitario) o '02' (valor referencial)");

            item.RuleFor(i => i.AfectacionIgv)
                .NotEmpty().WithMessage("La afectación IGV es obligatoria")
                .Must(id => cat07.ContainsKey(id))
                .WithMessage("La afectación IGV '{PropertyValue}' no es válida");

            item.RuleFor(i => i.Igv)
                .GreaterThanOrEqualTo(0).WithMessage("El IGV no puede ser negativo");

            item.When(i => !string.IsNullOrEmpty(i.AfectacionIgv) && IsGravado(i.AfectacionIgv), () =>
            {
                item.RuleFor(i => i.PorcentajeIgv)
                    .GreaterThan(0).WithMessage("El porcentaje IGV debe ser mayor a 0 para operaciones gravadas");
            });

            item.When(i => i.Isc != null, () =>
            {
                item.RuleFor(i => i.Isc!.Monto)
                    .GreaterThan(0).WithMessage("El monto ISC debe ser mayor a 0");

                item.RuleFor(i => i.Isc!.Sistema)
                    .NotEmpty().WithMessage("El sistema ISC es obligatorio")
                    .Must(id => cat16.ContainsKey(id))
                    .WithMessage("El sistema ISC '{PropertyValue}' no es válido");

                item.RuleFor(i => i.Isc!.Porcentaje)
                    .InclusiveBetween(0.01m, 100m).WithMessage("El porcentaje ISC debe estar entre 0.01 y 100");
            });

            item.When(i => i.Descuentos is { Count: > 0 }, () =>
            {
                item.RuleForEach(i => i.Descuentos).ChildRules(d =>
                {
                    d.RuleFor(x => x.Monto).GreaterThan(0).WithMessage("El monto del descuento debe ser mayor a 0");
                    d.RuleFor(x => x.Base).GreaterThan(0).WithMessage("La base del descuento debe ser mayor a 0");
                });
            });

            item.When(i => i.Cargos is { Count: > 0 }, () =>
            {
                item.RuleForEach(i => i.Cargos).ChildRules(c =>
                {
                    c.RuleFor(x => x.Monto).GreaterThan(0).WithMessage("El monto del cargo debe ser mayor a 0");
                    c.RuleFor(x => x.Base).GreaterThan(0).WithMessage("La base del cargo debe ser mayor a 0");
                });
            });
        });

        RuleForEach(r => r.Anticipos).ChildRules(anticipo =>
        {
            anticipo.RuleFor(a => a.TipoDocumento)
                .NotEmpty().WithMessage("El tipo de documento del anticipo es obligatorio")
                .Must(id => cat51.ContainsKey(id))
                .WithMessage("El tipo de documento de anticipo '{PropertyValue}' no es válido");

            anticipo.RuleFor(a => a.Numero)
                .NotEmpty().WithMessage("El número de anticipo es obligatorio");

            anticipo.RuleFor(a => a.Monto)
                .GreaterThan(0).WithMessage("El monto del anticipo debe ser mayor a 0");
        });

        When(r => r.Detraccion != null, () =>
        {
            RuleFor(r => r.Detraccion!.CodigoBien)
                .NotEmpty().WithMessage("El código de bien/servicio para detracción es obligatorio")
                .Must(id => cat52.ContainsKey(id))
                .WithMessage("El código de detracción '{PropertyValue}' no es válido");

            RuleFor(r => r.Detraccion!.Porcentaje)
                .InclusiveBetween(1, 100).WithMessage("El porcentaje de detracción debe estar entre 1 y 100");

            RuleFor(r => r.Detraccion!.Monto)
                .GreaterThan(0).WithMessage("El monto de detracción debe ser mayor a 0");
        });

        When(r => r.Percepcion != null, () =>
        {
            RuleFor(r => r.Percepcion!.Tasa)
                .InclusiveBetween(0.01m, 100m).WithMessage("La tasa de percepción debe estar entre 0.01 y 100");

            RuleFor(r => r.Percepcion!.Monto)
                .GreaterThan(0).WithMessage("El monto de percepción debe ser mayor a 0");
        });

        When(r => r.DocumentosRelacionados is { Count: > 0 }, () =>
        {
            RuleForEach(r => r.DocumentosRelacionados).ChildRules(doc =>
            {
                doc.RuleFor(d => d.TipoDocumento)
                    .NotEmpty().WithMessage("El tipo de documento relacionado es obligatorio");

                doc.RuleFor(d => d.Numero)
                    .NotEmpty().WithMessage("El número de documento relacionado es obligatorio");
            });
        });

        When(r => r.GuiasRemision is { Count: > 0 }, () =>
        {
            RuleForEach(r => r.GuiasRemision).ChildRules(guia =>
            {
                guia.RuleFor(g => g.TipoDocumento)
                    .NotEmpty().WithMessage("El tipo de guía de remisión es obligatorio");

                guia.RuleFor(g => g.Numero)
                    .NotEmpty().WithMessage("El número de guía de remisión es obligatorio");
            });
        });
    }

    private static bool IsGravado(string afectacion)
    {
        return afectacion is "10" or "11" or "12" or "13" or "14" or "15" or "16" or "17";
    }
}
