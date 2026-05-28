# Fact — API de Facturación Electrónica SUNAT (UBL 2.1)

## Propósito

API REST construida en **.NET 8 (C#)** que genera, firma digitalmente y envía facturas electrónicas peruanas (UBL 2.1) al **SUNAT OSE** (Operador de Servicios Electrónicos).

El flujo completo:

```
Frontend → POST /api/invoice/send → Genera XML UBL 2.1 → Firma XMLDSig → SOAP → SUNAT OSE → CDR
```

No usa base de datos. Todo se genera en memoria (XML + firma + envío).

---

## Stack Tecnológico

| Componente | Elección | Motivo |
|-----------|----------|--------|
| Lenguaje | C# (.NET 8) | XMLDSig nativo con `System.Security.Cryptography.Xml` |
| Framework | ASP.NET Core WebAPI | REST controllers, DI, config |
| Tests | xUnit | Estándar .NET |
| Firmas | `System.Security.Cryptography.Xml` | XMLDSig enveloped, RSA-SHA1, C14N |
| SOAP | `HttpClient` + `System.Xml` | Envío a SUNAT OSE |
| Catálogos | JSON files (13) | Cargados en memoria al startup, sin DB |

---

## Estructura del Proyecto

```
Fact.sln
├── Fact.Core/                      # Lógica de negocio
│   ├── Models/
│   │   ├── InvoiceRequest.cs       # DTO de entrada (todos los campos)
│   │   ├── InvoiceResponse.cs      # DTO de salida
│   │   ├── Emisor.cs               # Datos del emisor
│   │   ├── Adquirente.cs           # Datos del adquirente
│   │   ├── ItemFactura.cs          # Ítem de factura
│   │   ├── IscInfo.cs              # ISC por ítem
│   │   ├── AnticipoInfo.cs         # Anticipo
│   │   ├── DetraccionInfo.cs       # Detracción
│   │   ├── PercepcionInfo.cs       # Percepción
│   │   ├── DescuentoCargo.cs       # Descuento/cargo global
│   │   ├── EntregaInfo.cs          # Dirección de entrega (opcional)
│   │   ├── GuiaRemisionInfo.cs     # Guía de remisión (opcional)
│   │   └── AdditionalProperty.cs   # Propiedades adicionales
│   ├── Services/
│   │   ├── CatalogService.cs       # Carga catálogos SUNAT desde JSON
│   │   ├── XmlGeneratorService.cs  # Genera XML UBL 2.1 completo
│   │   ├── SignatureService.cs     # Firma digital XMLDSig
│   │   ├── SunatSenderService.cs   # SOAP client para SUNAT OSE
│   │   └── InvoiceService.cs       # Orchestrator (generate / sign / send)
│   └── Catalogs/json/              # 13 catálogos SUNAT
│       ├── catalogo01.json (Tipo de documento)
│       ├── catalogo03.json (Tipo de tributo)
│       ├── catalogo04.json (Códigos de tributo)
│       ├── catalogo05.json (Tipo de precio)
│       ├── catalogo06.json (Código de producto SUNAT)
│       ├── catalogo07.json (Afectación IGV)
│       ├── catalogo08.json (Tipo de operación)
│       ├── catalogo12.json (Tipo de descuento/cargo)
│       ├── catalogo16.json (Tipo de ISC)
│       ├── catalogo51.json (Tipo de anticipo)
│       ├── catalogo52.json (Código de detracción)
│       ├── catalogo53.json (Tipo de percepción)
│       └── catalogo55.json (Unidad de medida)
│
├── Fact.Api/                       # API REST
│   ├── Controllers/
│   │   └── InvoiceController.cs    # 4 endpoints REST
│   ├── Program.cs                  # DI, configuración, startup
│   └── appsettings.json            # SUNAT OSE URL
│
└── Fact.Tests/                     # Tests unitarios
    └── XmlGeneratorTests.cs        # 2 tests (básico + IGV/ISC)
```

---

## Endpoints REST

| Método | Ruta | Body | Respuesta | Descripción |
|--------|------|------|-----------|-------------|
| POST | `/api/invoice/generate-xml` | `InvoiceRequest` | XML string (200) | Genera XML UBL 2.1 |
| POST | `/api/invoice/generate-xml` | `InvoiceRequest` | XML string (200) | Genera XML UBL 2.1 |
| POST | `/api/invoice/generate-signed` | `InvoiceRequest` | XML firmado (200) | Genera + firma XML |
| POST | `/api/invoice/send` | `InvoiceRequest` | CDR / ticket (200) | Genera + firma + envía a SUNAT |
| POST | `/api/invoice/validate` | `InvoiceRequest` | Validación (200/400) | Valida request sin generar XML |

> **Nota:** Todos los parámetros de configuración (certificado .pfx, credenciales SUNAT) se cargan desde `appsettings.json`. No se requieren query params adicionales.

---

## Decisiones Técnicas Clave

### 1. Por qué .NET y no Node.js
Las librerías de firma XMLDSig en Node.js (`xml-crypto`) tienen limitaciones y bugs con los algoritmos que exige SUNAT (C14N, enveloped, RSA-SHA1). .NET tiene `System.Security.Cryptography.Xml` que es maduro y compatible.

### 2. IGV/ISC enviados desde frontend
El frontend envía `igv`, `porcentajeIgv`, `isc.monto`, `isc.porcentaje` por cada ítem. La API **no calcula** impuestos. Esto permite:
- Cambios en tasas sin actualizar el backend
- Casos especiales (exonerado, inafecto, gratuita)
- El frontend puede usar los catálogos para determinar la tasa

### 3. Sin base de datos
El proyecto genera únicamente el XML y lo envía. No se persisten facturas ni correlativos. El control de correlativos debe hacerlo el frontend.

### 4. Codificación ISO-8859-1
SUNAT exige XML con `<?xml version="1.0" encoding="ISO-8859-1"?>`. Se declara explícitamente en el `XmlDeclaration`.

### 5. Firma XMLDSig
- Algoritmo: RSA-SHA1 (SUNAT no soporta SHA256)
- Canonicalization: C14N (excluye comentarios)
- Transform: Enveloped signature
- X509Data: Se extrae del certificado .pfx (.NET `X509Certificate2`)

### 6. Catálogos desde JSON
Los 13 catálogos SUNAT se cargan desde archivos JSON en `Catalogs/json/` al startup. Se agrupan en `Dictionary<string, string>` para validación y referencia. No requieren DB ni recompilación para actualizarse.

---

## Features Completadas ✅

- [x] Creación de solución .NET 8 con 3 proyectos (Api, Core, Tests)
- [x] Modelos completos para InvoiceRequest (Emisor, Adquirente, ItemFactura, ISC, Anticipos, Detracción, Percepción, Descuentos/Cargos, Entrega, Guías)
- [x] Catálogos SUNAT: 13 archivos JSON + CatalogService con carga en memoria
- [x] Generación XML UBL 2.1 completa:
  - Invoice tags obligatorios (UBLVersionID, ProfileID, ID, IssueDate, IssueTime, InvoiceTypeCode, DocumentCurrencyCode)
  - AccountingSupplierParty + CustomerParty
  - TaxTotal con IGV, ISC, y otros tributos
  - LegalMonetaryTotal (PayableAmount con descuentos/cargos globales)
  - InvoiceLine completo (PricingReference, AllowanceCharge, Item, Price)
  - ISC por ítem (con código 2000 y subtotales)
  - Anticipos (PrepaidPayment)
  - Detracción (PayableRoundingAmount + SAC de detracción)
  - Percepción (PerceptionReference)
  - Descuentos/Cargos globales (en LegalMonetaryTotal)
  - AllowanceCharge por ítem (descuentos y cargos a nivel línea)
  - AdditionalItemProperty (para bolsa plástica, etc.)
  - Delivery (DirecciónEntrega, opcional)
  - DespatchDocumentReference (Guías de Remisión, opcional)
- [x] Firma digital XMLDSig (RSA-SHA1, C14N, enveloped, X509)
- [x] Envío SOAP a SUNAT OSE (e-beta: `https://e-beta.sunat.gob.pe/ol-ti-itcpfegem/billService`)
- [x] InvoiceService orchestrator (Generate / GenerateAndSign / GenerateSignAndSend)
- [x] InvoiceController con 4 endpoints REST
- [x] DI registrado en Program.cs (servicios como singletons, HttpClientFactory)
- [x] Configuración SUNAT OSE URL desde `appsettings.json`
- [x] JSON camelCase naming policy en API
- [x] 2 tests unitarios (básico + IGV/ISC) — todos pasan
- [x] Build exitoso — `dotnet build` sin errores
- [x] API responde correctamente: `curl POST /api/invoice/generate-xml` retorna XML UBL 2.1 válido
- [x] Certificado .pfx de prueba autofirmado en `certs/test-cert.pfx` (password: `12345`)
- [x] FluentValidation para `InvoiceRequest` con validación de:
  - Campos obligatorios (serie, número, fechas, emisor, adquirente, items)
  - Formato de RUC (11 dígitos), serie, fechas, horas
  - Validación contra catálogos SUNAT (tipo operación, tipo documento, unidad medida, afectación IGV, etc.)
  - Validación anidada de Items (ISC, descuentos, cargos), Anticipos, Documentos de Referencia
  - Validación condicional de Detracción y Percepción
- [x] Documentación Swagger/OpenAPI con XML comments y descripción de API
- [x] Middleware global de manejo de excepciones (ExceptionMiddleware)
- [x] Sample request completo en `sample-request.json` con todos los casos:
  - IGV + ISC combinados por ítem
  - Operación gratuita (afectación IGV = "21")
  - Bien exonerado (afectación IGV = "20")
  - Anticipos
  - Detracción + Percepción
  - Descuento global + descuento por ítem
  - Cargo global
  - Bolsa plástica (AdditionalProperty codigo "4100")
  - Guía de remisión
  - Dirección de entrega
  - Documentos relacionados
  - Leyendas
  - Múltiples ítems (4)

---

## Features Pendientes 📋

- [ ] Probar endpoint `generate-signed` con el certificado de prueba autofirmado
- [ ] Probar contra SUNAT beta OSE con credenciales reales de prueba
- [ ] Logging estructurado (Serilog o ILogger)
- [ ] Pruebas de integración para los endpoints con certificado

---

## Estado Actual

| Aspecto | Estado |
|---------|--------|
| Build | ✅ Sin errores |
| Tests | ✅ 2/2 pasan |
| API running | ✅ `http://localhost:5000` |
| Certificado .pfx | ✅ `certs/test-cert.pfx` (password: `12345`) |
| Credenciales SUNAT | ❌ No configuradas |
| Validación request | ✅ FluentValidation con catálogos |
| Swagger | ✅ Disponible en `/swagger` (development) |
| Exception Middleware | ✅ Global |
| Sample Request | ✅ `sample-request.json` |

---

## Comandos Útiles

```bash
# Build
dotnet build

# Test
dotnet test

# Run API
dotnet run --project Fact.Api

# Ejemplo curl (generate-xml)
curl -s -X POST http://localhost:5000/api/invoice/generate-xml \
  -H "Content-Type: application/json" \
  -d @sample-request.json | xmllint --format -

# Ejemplo curl (generate-signed, con certificado de prueba)
curl -s -X POST "http://localhost:5000/api/invoice/generate-signed?certPath=certs/test-cert.pfx&certPassword=12345" \
  -H "Content-Type: application/json" \
  -d @sample-request.json | xmllint --format -

# Acceder a Swagger UI (solo development)
# Abrir en navegador: http://localhost:5000/swagger
```

---

## Archivos Relevantes

| Archivo | Propósito |
|---------|-----------|
| `Fact.sln` | Solución .NET |
| `Fact.Api/Program.cs` | Startup, DI, configuración |
| `Fact.Api/Controllers/InvoiceController.cs` | Endpoints REST |
| `Fact.Api/appsettings.json` | Config (URL SUNAT) |
| `Fact.Core/Models/InvoiceRequest.cs` | DTO entrada principal |
| `Fact.Core/Models/InvoiceResponse.cs` | DTO salida |
| `Fact.Core/Models/Emisor.cs` | Datos del emisor |
| `Fact.Core/Models/Adquirente.cs` | Datos del adquirente |
| `Fact.Core/Models/ItemFactura.cs` | Ítem de línea |
| `Fact.Core/Models/IscInfo.cs` | ISC por ítem |
| `Fact.Core/Models/AnticipoInfo.cs` | Anticipo |
| `Fact.Core/Models/DetraccionInfo.cs` | Detracción |
| `Fact.Core/Models/PercepcionInfo.cs` | Percepción |
| `Fact.Core/Models/DescuentoCargo.cs` | Descuento/cargo global |
| `Fact.Core/Models/EntregaInfo.cs` | Dirección de entrega |
| `Fact.Core/Models/GuiaRemisionInfo.cs` | Guía de remisión |
| `Fact.Core/Models/AdditionalProperty.cs` | Propiedad adicional |
| `Fact.Core/Services/CatalogService.cs` | Carga catálogos JSON |
| `Fact.Core/Services/XmlGeneratorService.cs` | Generación XML (~350 loc) |
| `Fact.Core/Services/SignatureService.cs` | Firma XMLDSig |
| `Fact.Core/Services/SunatSenderService.cs` | Cliente SOAP SUNAT |
| `Fact.Core/Services/InvoiceService.cs` | Orchestrator |
| `Fact.Core/Validators/InvoiceRequestValidator.cs` | FluentValidation de entrada |
| `Fact.Core/Catalogs/json/*.json` | 13 catálogos SUNAT |
| `Fact.Api/Middleware/ExceptionMiddleware.cs` | Middleware global de errores |
| `Fact.Tests/XmlGeneratorTests.cs` | Tests unitarios |
| `certs/test-cert.pfx` | Certificado de prueba autofirmado |
| `sample-request.json` | Request de ejemplo completo |
