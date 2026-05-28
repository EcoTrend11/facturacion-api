# Fact API

REST API en .NET 8 para generar, firmar digitalmente y enviar facturas electrónicas (UBL 2.1) al SUNAT OSE (Operador de Servicios Electrónicos).

## Stack

- **.NET 8** (C#)
- **FluentValidation** — validación de datos de entrada
- **Swagger/OpenAPI** — documentación interactiva
- **XMLDSig** — firma digital enveloped (RSA-SHA1, C14N)
- **Docker** — imagen multi-stage (~200MB)

## Estructura del proyecto

```
Fact.sln
├── Fact.Api/          API REST (controllers, middleware, Program.cs)
├── Fact.Core/         Lógica de negocio (models, services, validators, catálogos)
└── Fact.Tests/        Tests unitarios
```

### Fact.Api
- `Controllers/InvoiceController.cs` — 4 endpoints
- `Middleware/ExceptionMiddleware.cs` — manejo global de errores
- `Program.cs` — configuración de DI, Swagger, middleware

### Fact.Core
- `Models/` — DTOs (`InvoiceRequest`, `InvoiceResponse`, `SunatResponse`, etc.)
- `Services/` — `XmlGeneratorService`, `SignatureService`, `SunatSenderService`, `InvoiceService`
- `Validators/` — `InvoiceRequestValidator` (reglas FluentValidation)
- `Catalogs/json/` — 13 catálogos SUNAT en JSON

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Docker (opcional, para ejecutar sin instalar .NET)

## Configuración

`appsettings.json`:

```json
{
  "Sunat": {
    "OseUrl": "https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService",
    "Ruc": "20000000001",
    "Usuario": "MODDATOS",
    "Password": "moddatos"
  },
  "Certificate": {
    "Path": "../certs/test-cert.pfx",
    "Password": "12345"
  }
}
```

| Variable | Descripción |
|---|---|
| `Sunat:OseUrl` | URL del OSE (beta o producción) |
| `Sunat:Ruc` | RUC del emisor |
| `Sunat:Usuario` | Usuario SOL |
| `Sunat:Password` | Clave SOL |
| `Certificate:Path` | Ruta al certificado digital `.pfx` |
| `Certificate:Password` | Contraseña del certificado |

En Docker se sobreescribe `Certificate__Path` a `certs/test-cert.pfx`.

### Certificado de prueba

`certs/test-cert.pfx` contiene un certificado autofirmado para SUNAT beta. No es válido para producción.

## Ejecutar local

```bash
# Restaurar dependencias
dotnet restore

# Ejecutar la API
dotnet run --project Fact.Api

# La API inicia en http://localhost:5000
# Swagger en http://localhost:5000/swagger
```

## Ejecutar con Docker

```bash
# Construir imagen
docker build -t fact-api .

# Ejecutar contenedor
docker run -d --name fact -p 5000:5000 fact-api

# Ver logs
docker logs fact

# Detener y eliminar
docker stop fact && docker rm fact
```

Para producción con cert real y credenciales reales:

```bash
docker run -d --name fact \
  -p 5000:5000 \
  -e Sunat__OseUrl="https://e-factura.sunat.gob.pe/..." \
  -e Sunat__Ruc="20123456789" \
  -e Sunat__Usuario="REALUSER" \
  -e Sunat__Password="REALPASS" \
  -e Certificate__Path="certs/prod-cert.pfx" \
  -e Certificate__Password="realpassword" \
  -v $(pwd)/certs/prod-cert.pfx:/app/certs/prod-cert.pfx \
  fact-api
```

## Endpoints

### `POST /api/Invoice/generate-xml`

Genera el XML UBL 2.1 de la factura. No firma ni envía.

**Respuesta exitosa:**
```json
{
  "exitoso": true,
  "mensaje": "XML generado correctamente",
  "xmlBase64": "...",
  "serieNumero": "F001-1"
}
```

### `POST /api/Invoice/generate-signed`

Genera y firma digitalmente el XML.

**Respuesta exitosa:**
```json
{
  "exitoso": true,
  "mensaje": "XML generado y firmado correctamente",
  "xmlFirmado": "<Invoice>...",
  "xmlBase64": "...",
  "serieNumero": "F001-1",
  "hashFirma": "..."
}
```

### `POST /api/Invoice/send`

Genera, firma, comprime en ZIP y envía al SUNAT OSE vía SOAP. Devuelve el CDR (Comprobante de Recepción).

**Respuesta exitosa:**
```json
{
  "exitoso": true,
  "mensaje": "Factura enviada y aceptada por SUNAT",
  "xmlFirmado": "...",
  "xmlBase64": "...",
  "serieNumero": "F001-1",
  "hashFirma": "...",
  "envioSunat": {
    "exitoso": true,
    "codigo": "0",
    "descripcion": "Aceptado",
    "numeroCdr": "1779927520967",
    "cdrBase64": "..."
  }
}
```

Códigos de respuesta SUNAT: `0` = Aceptado, cualquier otro = Rechazado.

### `POST /api/Invoice/validate`

Valida los datos de entrada contra las reglas de SUNAT (catálogos, formato RUC, campos obligatorios, etc.). No genera XML.

**Respuesta con errores:**
```json
{
  "exitoso": false,
  "mensaje": "Errores de validación: [Serie] La serie es obligatoria; ..."
}
```

## Modelo de request

Ver `sample-request.json` para un ejemplo completo con todos los campos.

Campos principales del `InvoiceRequest`:

| Campo | Tipo | Descripción |
|---|---|---|
| `serie` | string | Serie del documento (ej. F001) |
| `numero` | int | Número correlativo |
| `fechaEmision` | string | Formato yyyy-MM-dd |
| `horaEmision` | string | Formato HH:mm:ss |
| `tipoOperacion` | string | Catálogo 01 (ej. 0101) |
| `moneda` | string | ISO 4217 (PEN, USD) |
| `formaPago` | string | Contado / Crédito |
| `emisor` | object | RUC, razón social, código domicilio fiscal |
| `adquirente` | object | Tipo/número documento, razón social |
| `items[]` | array | Líneas de factura |
| `guiasRemision[]` | array | Guías de remisión relacionadas |
| `documentosRelacionados[]` | array | Otros documentos relacionados |
| `impuestos[]` | array | Impuestos globales (ISC, etc.) |
| `descuentosGlobales[]` | array | Descuentos a nivel factura |
| `cargosGlobales[]` | array | Cargos a nivel factura |
| `anticipos[]` | array | Anticipos |
| `detraccion` | object | Detracción (opcional) |
| `percepcion` | object | Percepción (opcional) |
| `entrega` | object | Dirección de entrega (opcional) |

Cada item soporta:
- IGV individual (monto y porcentaje)
- ISC opcional (monto, sistema, porcentaje)
- Descuentos y cargos por línea
- Propiedades adicionales
- Códigos de producto (propio y SUNAT)

**Importante:** El API no calcula IGV/ISC. El frontend debe enviar los montos calculados.

## Tests

```bash
dotnet test
```

Actualmente 2 tests que verifican:
- Generación básica de XML
- Generación con IGV + ISC

## Catálogos SUNAT

Los 13 catálogos se cargan desde `Fact.Core/Catalogs/json/` al iniciar la aplicación. Se pueden actualizar sin recompilar.

## Notas

- HTTPS debe manejarse en el reverse proxy (Nginx, Cloudflare), no en la app
- El certificado debe tener clave RSA para firmar digitalmente
- Para SUNAT beta usar OSE URL beta y certificado autofirmado
- Para producción se requiere certificado registrado y credenciales SOL reales
