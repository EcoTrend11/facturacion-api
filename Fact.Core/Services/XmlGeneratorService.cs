using System.Xml.Linq;
using Fact.Core.Models;

namespace Fact.Core.Services;

public class XmlGeneratorService : IXmlGeneratorService
{
    private static readonly XNamespace ns = "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2";
    private static readonly XNamespace cac = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2";
    private static readonly XNamespace cbc = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2";
    private static readonly XNamespace ext = "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2";
    private static readonly XNamespace ds = "http://www.w3.org/2000/09/xmldsig#";

    private readonly ICatalogService _catalog;

    public XmlGeneratorService(ICatalogService catalog)
    {
        _catalog = catalog;
    }

    public XDocument GenerateInvoice(InvoiceRequest request)
    {
        var doc = new XDocument(
            new XDeclaration("1.0", "ISO-8859-1", "no"),
            new XElement(ns + "Invoice",
                new XAttribute(XNamespace.Xmlns + "cac", cac),
                new XAttribute(XNamespace.Xmlns + "cbc", cbc),
                new XAttribute(XNamespace.Xmlns + "ext", ext),
                new XAttribute(XNamespace.Xmlns + "ds", ds),

                BuildUBLExtensions(),

                new XElement(cbc + "UBLVersionID", "2.1"),
                new XElement(cbc + "CustomizationID", "2.0"),

                BuildProfileId(request.TipoOperacion),
                new XElement(cbc + "ID", $"{request.Serie}-{request.Numero}"),
                new XElement(cbc + "IssueDate", request.FechaEmision),
                new XElement(cbc + "IssueTime", request.HoraEmision),

                BuildDueDate(request.FechaVencimiento),
                BuildInvoiceTypeCode(request.TipoOperacion),
                BuildNotes(request.Leyendas),
                BuildCurrencyCode(request.Moneda),
                BuildLineCount(request.Items),

                BuildOrderReference(request.OrdenCompra),
                BuildDespatchReferences(request.GuiasRemision),
                BuildAdditionalDocReferences(request.DocumentosRelacionados),

                BuildSignature(request.Emisor.Ruc, request.Emisor.RazonSocial),

                BuildSupplierParty(request.Emisor),
                BuildCustomerParty(request.Adquirente),

                BuildPaymentTerms(request.FormaPago),
                BuildDeliveryTerms(request.Entrega),
                BuildGlobalAllowanceCharges(request.DescuentosGlobales, request.CargosGlobales),
                BuildPrepaidPayments(request.Anticipos),
                BuildDetraction(request.Detraccion),
                BuildPerception(request.Percepcion),

                BuildTaxTotal(request),
                BuildLegalMonetaryTotal(request),
                BuildInvoiceLines(request.Items)
            )
        );
        return doc;
    }

    private XElement BuildUBLExtensions()
    {
        return new XElement(ext + "UBLExtensions",
            new XElement(ext + "UBLExtension",
                new XElement(ext + "ExtensionContent")
            )
        );
    }

    private static XElement BuildProfileId(string tipoOperacion)
    {
        return new XElement(cbc + "ProfileID",
            new XAttribute("schemeID", "01"),
            new XAttribute("schemeName", "SUNAT:Identificador de Tipo de Operación"),
            new XAttribute("schemeAgencyName", "PE:SUNAT"),
            new XAttribute("schemeURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01"),
            tipoOperacion);
    }

    private static XElement? BuildDueDate(string? fechaVencimiento)
    {
        return fechaVencimiento is { Length: > 0 }
            ? new XElement(cbc + "DueDate", fechaVencimiento)
            : null;
    }

    private static XElement BuildInvoiceTypeCode(string tipoOperacion)
    {
        return new XElement(cbc + "InvoiceTypeCode",
            new XAttribute("listID", tipoOperacion),
            "01");
    }

    private static XElement[] BuildNotes(List<Leyenda> leyendas)
    {
        return leyendas.Select(l =>
            new XElement(cbc + "Note",
                new XAttribute("languageLocaleID", l.Codigo),
                l.Texto ?? "")).ToArray();
    }

    private static XElement BuildCurrencyCode(string moneda)
    {
        return new XElement(cbc + "DocumentCurrencyCode",
            new XAttribute("listID", "ISO 4217 Alpha"),
            new XAttribute("listName", "Currency"),
            new XAttribute("listAgencyName", "United Nations Economic Commission for Europe"),
            moneda);
    }

    private static XElement? BuildLineCount(List<ItemFactura> items)
    {
        return items.Count > 0
            ? new XElement(cbc + "LineCountNumeric", items.Count)
            : null;
    }

    private static XElement? BuildOrderReference(string? ordenCompra)
    {
        return ordenCompra is { Length: > 0 }
            ? new XElement(cac + "OrderReference",
                new XElement(cbc + "ID", ordenCompra))
            : null;
    }

    private static XElement[] BuildDespatchReferences(List<DocumentoReferencia> guias)
    {
        return guias.Select(g =>
            new XElement(cac + "DespatchDocumentReference",
                new XElement(cbc + "ID", g.Numero),
                new XElement(cbc + "DocumentTypeCode",
                    new XAttribute("listAgencyName", "PE:SUNAT"),
                    new XAttribute("listName", "SUNAT:Identificador de guía relacionada"),
                    new XAttribute("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo01"),
                    g.TipoDocumento))
        ).ToArray();
    }

    private static XElement[] BuildAdditionalDocReferences(List<DocumentoReferencia> docs)
    {
        return docs.Select(d =>
            new XElement(cac + "AdditionalDocumentReference",
                new XElement(cbc + "ID", d.Numero),
                new XElement(cbc + "DocumentTypeCode",
                    new XAttribute("listAgencyName", "PE:SUNAT"),
                    new XAttribute("listName", "SUNAT:Identificador de documento relacionado"),
                    new XAttribute("listURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo12"),
                    d.TipoDocumento))
        ).ToArray();
    }

    private static XElement BuildSignature(string ruc, string razonSocial)
    {
        var signatureId = "SignFact";
        return new XElement(cac + "Signature",
            new XElement(cbc + "ID", $"ID{signatureId}"),
            new XElement(cac + "SignatoryParty",
                new XElement(cac + "PartyIdentification",
                    new XElement(cbc + "ID", ruc)),
                new XElement(cac + "PartyName",
                    new XElement(cbc + "Name", razonSocial))),
            new XElement(cac + "DigitalSignatureAttachment",
                new XElement(cac + "ExternalReference",
                    new XElement(cbc + "URI", $"#{signatureId}"))));
    }

    private XElement BuildSupplierParty(Emisor emisor)
    {
        return new XElement(cac + "AccountingSupplierParty",
            new XElement(cac + "Party",
                new XElement(cac + "PartyIdentification",
                    new XElement(cbc + "ID",
                        new XAttribute("schemeID", "6"),
                        emisor.Ruc)),
                new XElement(cac + "PartyName",
                    new XElement(cbc + "Name", emisor.NombreComercial ?? emisor.RazonSocial)),
                new XElement(cac + "PartyTaxScheme",
                    new XElement(cac + "TaxScheme",
                        new XElement(cbc + "ID", "-"))),
                new XElement(cac + "PartyLegalEntity",
                    new XElement(cbc + "RegistrationName", emisor.RazonSocial),
                    new XElement(cac + "RegistrationAddress",
                        new XElement(cbc + "AddressTypeCode", emisor.CodigoDomicilioFiscal)))));
    }

    private XElement BuildCustomerParty(Adquirente adquirente)
    {
        return new XElement(cac + "AccountingCustomerParty",
            new XElement(cac + "Party",
                new XElement(cac + "PartyIdentification",
                    new XElement(cbc + "ID",
                        new XAttribute("schemeID", adquirente.TipoDocumento),
                        adquirente.NumeroDocumento)),
                new XElement(cac + "PartyTaxScheme",
                    new XElement(cac + "TaxScheme",
                        new XElement(cbc + "ID", "-"))),
                new XElement(cac + "PartyLegalEntity",
                    new XElement(cbc + "RegistrationName", adquirente.RazonSocial))));
    }

    private static XElement BuildPaymentTerms(string formaPago)
    {
        return new XElement(cac + "PaymentTerms",
            new XElement(cbc + "ID", "FormaPago"),
            new XElement(cbc + "PaymentMeansID", formaPago));
    }

    private static XElement? BuildDeliveryTerms(DireccionEntrega? entrega)
    {
        if (entrega == null) return null;

        return new XElement(cac + "DeliveryTerms",
            new XElement(cac + "DeliveryLocation",
                new XElement(cac + "Address",
                    new XElement(cbc + "StreetName", entrega.Direccion ?? ""),
                    new XElement(cbc + "CitySubdivisionName"),
                    new XElement(cbc + "CityName", entrega.Provincia ?? ""),
                    new XElement(cbc + "CountrySubentity", entrega.Departamento ?? ""),
                    new XElement(cbc + "CountrySubentityCode", entrega.Ubigeo ?? ""),
                    new XElement(cbc + "District", entrega.Distrito ?? ""),
                    new XElement(cac + "Country",
                        new XElement(cbc + "IdentificationCode",
                            new XAttribute("listID", "ISO 3166-1"),
                            new XAttribute("listAgencyName", "United Nations Economic Commission for Europe"),
                            new XAttribute("listName", "Country"),
                            entrega.CodigoPais ?? "PE")))));
    }

    private static XElement[] BuildGlobalAllowanceCharges(
        List<DescuentoCargo> descuentos, List<DescuentoCargo> cargos)
    {
        return descuentos.Concat(cargos).Select(dc => BuildAllowanceCharge(dc)).ToArray();
    }

    private static XElement BuildAllowanceCharge(DescuentoCargo dc)
    {
        var el = new XElement(cac + "AllowanceCharge",
            new XElement(cbc + "ChargeIndicator", dc.Indicador ? "true" : "false"),
            new XElement(cbc + "AllowanceChargeReasonCode", dc.CodigoMotivo),
            dc.Factor.HasValue
                ? new XElement(cbc + "MultiplierFactorNumeric", dc.Factor.Value)
                : null,
            new XElement(cbc + "Amount",
                new XAttribute("currencyID", "PEN"), dc.Monto),
            new XElement(cbc + "BaseAmount",
                new XAttribute("currencyID", "PEN"), dc.Base));
        return el;
    }

    private static XElement[] BuildPrepaidPayments(List<Anticipo> anticipos)
    {
        return anticipos.Select(a =>
            new XElement(cac + "PrepaidPayment",
                new XElement(cbc + "ID",
                    new XAttribute("schemeID", a.TipoDocumento),
                    a.Numero),
                new XElement(cbc + "PaidAmount",
                    new XAttribute("currencyID", a.Moneda), a.Monto),
                string.IsNullOrEmpty(a.RucEmisor) ? null :
                    new XElement(cbc + "InstructionID",
                        new XAttribute("schemeID", "6"),
                        a.RucEmisor))
        ).ToArray();
    }

    private static XElement? BuildDetraction(Detraccion? detraccion)
    {
        if (detraccion == null) return null;

        var el = new XElement(cac + "PaymentMeans",
            new XElement(cac + "PayeeFinancialAccount",
                new XElement(cbc + "ID", detraccion.CuentaBancoNacion ?? "")));

        el.Add(new XElement(cac + "PaymentTerms",
            new XElement(cbc + "ID",
                new XAttribute("schemeName", "SUNAT:Codigo de detraccion"),
                new XAttribute("schemeAgencyName", "PE:SUNAT"),
                new XAttribute("schemeURI", "urn:pe:gob:sunat:cpe:see:gem:catalogos:catalogo54"),
                detraccion.CodigoBien),
            new XElement(cbc + "PaymentPercent", detraccion.Porcentaje),
            new XElement(cbc + "Amount", detraccion.Monto)));

        return el;
    }

    private static XElement? BuildPerception(Percepcion? percepcion)
    {
        if (percepcion == null) return null;

        return new XElement(cac + "AllowanceCharge",
            new XElement(cbc + "ChargeIndicator", "true"),
            new XElement(cbc + "AllowanceChargeReasonCode", "51"),
            new XElement(cbc + "MultiplierFactorNumeric", percepcion.Tasa),
            new XElement(cbc + "Amount",
                new XAttribute("currencyID", "PEN"), percepcion.Monto),
            new XElement(cbc + "BaseAmount",
                new XAttribute("currencyID", "PEN"), 0m));
    }

    private XElement BuildTaxTotal(InvoiceRequest request)
    {
        var totalImpuestos = request.Impuestos.Sum(i => i.Monto);
        if (request.Items.Sum(i => i.Igv) > 0 && request.Impuestos.Count == 0)
        {
            var gravados = request.Items.Sum(i => i.ValorVenta);
            totalImpuestos = request.Items.Sum(i => i.Igv);
            var tax = new XElement(cac + "TaxTotal",
                new XElement(cbc + "TaxAmount",
                    new XAttribute("currencyID", request.Moneda), totalImpuestos));
            foreach (var item in request.Items)
            {
                if (item.Igv <= 0 && item.Isc != null) continue;
            }
            BuildTaxSubtotal(request, tax);
            return tax;
        }

        var taxTotal = new XElement(cac + "TaxTotal",
            new XElement(cbc + "TaxAmount",
                new XAttribute("currencyID", request.Moneda), totalImpuestos));

        foreach (var imp in request.Impuestos)
        {
            taxTotal.Add(BuildTaxSubtotalFromRequest(imp, request.Moneda));
        }

        return taxTotal;
    }

    private void BuildTaxSubtotal(InvoiceRequest request, XElement taxTotal)
    {
        var gravados = request.Items
            .Where(i => i.AfectacionIgv is "10" or "11" or "12" or "13" or "14" or "15" or "16")
            .Sum(i => i.ValorVenta);

        if (gravados > 0)
        {
            var igv = request.Items
                .Where(i => i.AfectacionIgv is "10" or "11" or "12" or "13" or "14" or "15" or "16")
                .Sum(i => i.Igv);

            taxTotal.Add(new XElement(cac + "TaxSubtotal",
                new XElement(cbc + "TaxableAmount",
                    new XAttribute("currencyID", request.Moneda), gravados),
                new XElement(cbc + "TaxAmount",
                    new XAttribute("currencyID", request.Moneda), igv),
                new XElement(cac + "TaxCategory",
                    new XElement(cbc + "ID",
                        new XAttribute("schemeID", "UN/ECE 5305"),
                        new XAttribute("schemeName", "Tax Category Identifier"),
                        new XAttribute("schemeAgencyName", "United Nations Economic Commission for Europe"),
                        "S"),
                    new XElement(cac + "TaxScheme",
                        new XElement(cbc + "ID",
                            new XAttribute("schemeID", "UN/ECE 5153"),
                            new XAttribute("schemeAgencyID", "6"),
                            "1000"),
                        new XElement(cbc + "Name", "IGV"),
                        new XElement(cbc + "TaxTypeCode", "VAT")))));
        }

        var exonerados = request.Items
            .Where(i => i.AfectacionIgv == "20")
            .Sum(i => i.ValorVenta);

        if (exonerados > 0)
        {
            taxTotal.Add(new XElement(cac + "TaxSubtotal",
                new XElement(cbc + "TaxableAmount",
                    new XAttribute("currencyID", request.Moneda), exonerados),
                new XElement(cbc + "TaxAmount",
                    new XAttribute("currencyID", request.Moneda), 0m),
                new XElement(cac + "TaxCategory",
                    new XElement(cbc + "ID",
                        new XAttribute("schemeID", "UN/ECE 5305"),
                        new XAttribute("schemeName", "Tax Category Identifier"),
                        new XAttribute("schemeAgencyName", "United Nations Economic Commission for Europe"),
                        "E"),
                    new XElement(cac + "TaxScheme",
                        new XElement(cbc + "ID",
                            new XAttribute("schemeID", "UN/ECE 5153"),
                            new XAttribute("schemeAgencyID", "6"),
                            "9997"),
                        new XElement(cbc + "Name", "EXONERADO"),
                        new XElement(cbc + "TaxTypeCode", "VAT")))));
        }
    }

    private static XElement BuildTaxSubtotalFromRequest(ImpuestoGlobal imp, string moneda)
    {
        return new XElement(cac + "TaxSubtotal",
            new XElement(cbc + "TaxableAmount",
                new XAttribute("currencyID", moneda), imp.MontoBase),
            new XElement(cbc + "TaxAmount",
                new XAttribute("currencyID", moneda), imp.Monto),
            new XElement(cac + "TaxCategory",
                new XElement(cbc + "ID",
                    new XAttribute("schemeID", "UN/ECE 5305"),
                    new XAttribute("schemeName", "Tax Category Identifier"),
                    new XAttribute("schemeAgencyName", "United Nations Economic Commission for Europe"),
                    imp.Categoria),
                new XElement(cac + "TaxScheme",
                    new XElement(cbc + "ID",
                        new XAttribute("schemeID", "UN/ECE 5153"),
                        new XAttribute("schemeAgencyID", "6"),
                        imp.Id),
                    new XElement(cbc + "Name", imp.Nombre),
                    new XElement(cbc + "TaxTypeCode", imp.CodigoInternacional))));
    }

    private static XElement BuildLegalMonetaryTotal(InvoiceRequest request)
    {
        var totalValorVenta = request.Items.Sum(i => i.ValorVenta);
        var totalImpuestos = request.Impuestos.Count > 0
            ? request.Impuestos.Sum(i => i.Monto)
            : request.Items.Sum(i => i.Igv);
        var totalDescuentos = request.DescuentosGlobales.Sum(d => d.Monto)
                              + request.Items.Sum(i => i.Descuentos.Sum(d => d.Monto));
        var totalCargos = request.CargosGlobales.Sum(c => c.Monto)
                          + request.Items.Sum(i => i.Cargos.Sum(c => c.Monto))
                          + (request.Percepcion?.Monto ?? 0);
        var totalAnticipos = request.Anticipos.Sum(a => a.Monto);
        var totalPrecioVenta = totalValorVenta - totalDescuentos + totalCargos + totalImpuestos;
        var totalPagar = totalPrecioVenta - totalAnticipos;

        return new XElement(cac + "LegalMonetaryTotal",
            new XElement(cbc + "LineExtensionAmount",
                new XAttribute("currencyID", request.Moneda), totalValorVenta),
            new XElement(cbc + "TaxInclusiveAmount",
                new XAttribute("currencyID", request.Moneda), totalPrecioVenta),
            totalDescuentos > 0
                ? new XElement(cbc + "AllowanceTotalAmount",
                    new XAttribute("currencyID", request.Moneda), totalDescuentos)
                : null,
            totalCargos > 0
                ? new XElement(cbc + "ChargeTotalAmount",
                    new XAttribute("currencyID", request.Moneda), totalCargos)
                : null,
            totalAnticipos > 0
                ? new XElement(cbc + "PrepaidAmount",
                    new XAttribute("currencyID", request.Moneda), totalAnticipos)
                : null,
            new XElement(cbc + "PayableAmount",
                new XAttribute("currencyID", request.Moneda), totalPagar));
    }

    private XElement[] BuildInvoiceLines(List<ItemFactura> items)
    {
        return items.Select(item => BuildInvoiceLine(item)).ToArray();
    }

    private XElement BuildInvoiceLine(ItemFactura item)
    {
        var line = new XElement(cac + "InvoiceLine",
            new XElement(cbc + "ID", item.NumeroOrden),
            new XElement(cbc + "InvoicedQuantity",
                new XAttribute("unitCode", item.UnidadMedida),
                new XAttribute("unitCodeListID", "UN/ECE rec 20"),
                new XAttribute("unitCodeListAgencyName", "United Nations Economic Commission for Europe"),
                item.Cantidad),
            new XElement(cbc + "LineExtensionAmount",
                new XAttribute("currencyID", "PEN"), item.ValorVenta),

            BuildPricingReference(item),

            item.Descuentos.Select(BuildAllowanceCharge),
            item.Cargos.Select(BuildAllowanceCharge),

            BuildLineTaxTotal(item),

            new XElement(cac + "Item",
                new XElement(cbc + "Description", item.Descripcion),
                string.IsNullOrEmpty(item.CodigoProducto) ? null :
                    new XElement(cac + "SellersItemIdentification",
                        new XElement(cbc + "ID", item.CodigoProducto)),
                string.IsNullOrEmpty(item.CodigoProductoSunat) ? null :
                    new XElement(cac + "CommodityClassification",
                        new XElement(cbc + "ItemClassificationCode",
                            new XAttribute("listID", "UNSPSC"),
                            new XAttribute("listAgencyName", "GS1 US"),
                            new XAttribute("listName", "Item Classification"),
                            item.CodigoProductoSunat)),
                item.PropiedadesAdicionales.Select(BuildAdditionalProperty)
            ),

            new XElement(cac + "Price",
                new XElement(cbc + "PriceAmount",
                    new XAttribute("currencyID", "PEN"), item.ValorUnitario)));

        return line;
    }

    private static XElement BuildPricingReference(ItemFactura item)
    {
        return new XElement(cac + "PricingReference",
            new XElement(cac + "AlternativeConditionPrice",
                new XElement(cbc + "PriceAmount",
                    new XAttribute("currencyID", "PEN"), item.PrecioVentaUnitario),
                new XElement(cbc + "PriceTypeCode",
                    new XAttribute("listAgencyName", "PE:SUNAT"),
                    item.TipoPrecio)));
    }

    private XElement BuildLineTaxTotal(ItemFactura item)
    {
        var taxTotal = new XElement(cac + "TaxTotal",
            new XElement(cbc + "TaxAmount",
                new XAttribute("currencyID", "PEN"), item.Igv + (item.Isc?.Monto ?? 0)));

        // IGV subtotal
        var afectacionEntry = _catalog.GetCatalogo07().GetValueOrDefault(item.AfectacionIgv, "10");
        var isGravado = item.AfectacionIgv is "10" or "11" or "12" or "13" or "14" or "15" or "16";
        var isExonerado = item.AfectacionIgv == "20";
        var isInafecto = item.AfectacionIgv is "30" or "31" or "32" or "33" or "34" or "35" or "36" or "37";

        string categoriaId, tributoId, tributoName, tributoCode;
        if (isGravado)
        {
            categoriaId = "S"; tributoId = "1000"; tributoName = "IGV"; tributoCode = "VAT";
        }
        else if (isExonerado)
        {
            categoriaId = "E"; tributoId = "9997"; tributoName = "EXONERADO"; tributoCode = "VAT";
        }
        else
        {
            categoriaId = "O"; tributoId = "9998"; tributoName = "INAFECTO"; tributoCode = "FRE";
        }

        var taxableAmount = item.ValorVenta;

        taxTotal.Add(new XElement(cac + "TaxSubtotal",
            new XElement(cbc + "TaxableAmount",
                new XAttribute("currencyID", "PEN"), taxableAmount),
            new XElement(cbc + "TaxAmount",
                new XAttribute("currencyID", "PEN"), item.Igv),
            new XElement(cac + "TaxCategory",
                new XElement(cbc + "ID",
                    new XAttribute("schemeID", "UN/ECE 5305"),
                    new XAttribute("schemeName", "Tax Category Identifier"),
                    new XAttribute("schemeAgencyName", "United Nations Economic Commission for Europe"),
                    categoriaId),
                new XElement(cbc + "Percent", item.PorcentajeIgv),
                new XElement(cbc + "TaxExemptionReasonCode",
                    new XAttribute("listAgencyName", "PE:SUNAT"),
                    item.AfectacionIgv),
                new XElement(cac + "TaxScheme",
                    new XElement(cbc + "ID",
                        new XAttribute("schemeID", "UN/ECE 5153"),
                        new XAttribute("schemeAgencyID", "6"),
                        tributoId),
                    new XElement(cbc + "Name", tributoName),
                    new XElement(cbc + "TaxTypeCode", tributoCode)))));

        // ISC subtotal
        if (item.Isc is { Monto: > 0 })
        {
            taxTotal.Add(new XElement(cac + "TaxSubtotal",
                new XElement(cbc + "TaxableAmount",
                    new XAttribute("currencyID", "PEN"), item.ValorVenta),
                new XElement(cbc + "TaxAmount",
                    new XAttribute("currencyID", "PEN"), item.Isc.Monto),
                new XElement(cac + "TaxCategory",
                    new XElement(cbc + "ID",
                        new XAttribute("schemeID", "UN/ECE 5305"),
                        new XAttribute("schemeName", "Tax Category Identifier"),
                        new XAttribute("schemeAgencyName", "United Nations Economic Commission for Europe"),
                        "S"),
                    new XElement(cbc + "Percent", item.Isc.Porcentaje),
                    new XElement(cbc + "TaxExemptionReasonCode",
                        new XAttribute("listAgencyName", "PE:SUNAT"),
                        "10"),
                    new XElement(cbc + "TierRange", item.Isc.Sistema),
                    new XElement(cac + "TaxScheme",
                        new XElement(cbc + "ID",
                            new XAttribute("schemeID", "UN/ECE 5153"),
                            new XAttribute("schemeAgencyID", "6"),
                            "2000"),
                        new XElement(cbc + "Name", "ISC"),
                        new XElement(cbc + "TaxTypeCode", "EXC")))));
        }

        return taxTotal;
    }

    private static XElement BuildAdditionalProperty(PropiedadAdicional prop)
    {
        var el = new XElement(cac + "AdditionalItemProperty",
            new XElement(cbc + "Name", prop.Nombre),
            new XElement(cbc + "NameCode",
                new XAttribute("listName", "SUNAT:Identificador de la propiedad del ítem"),
                new XAttribute("listAgencyName", "PE:SUNAT"),
                prop.Codigo));

        if (prop.Valor != null)
            el.Add(new XElement(cbc + "Value", prop.Valor));
        if (prop.FechaInicio != null)
            el.Add(new XElement(cbc + "UsabilityPeriod",
                new XElement(cbc + "StartDate", prop.FechaInicio)));
        if (prop.FechaFin != null)
            el.Add(new XElement(cbc + "UsabilityPeriod",
                new XElement(cbc + "EndDate", prop.FechaFin)));
        if (prop.Duracion.HasValue)
            el.Add(new XElement(cbc + "DurationMeasure", prop.Duracion.Value));

        return el;
    }
}
