# AGENTS.md — Facturación API

.NET 8 REST API for Peruvian SUNAT electronic invoicing (UBL 2.1). Generates, signs, and sends invoices — no database, all in-memory.

## Commands

```bash
dotnet build                        # build solution
dotnet test                         # run 2 xUnit tests
dotnet run --project Fact.Api       # start on http://localhost:5067
docker build -t fact-api .          # multi-stage build
docker run -p 5000:5000 fact-api    # run container (env=Development)
```

## Architecture

- **Fact.Api/** — controllers, middleware, Program.cs (DI/startup)
- **Fact.Core/** — models, services, validators, 13 SUNAT catalog files (`Catalogs/json/`)
- **Fact.Tests/** — xUnit tests against Core + Api

Services: `CatalogService` (singleton), `XmlGeneratorService` (singleton), `SignatureService` (singleton), `InvoiceService` (scoped), `SunatSenderService` (via `AddHttpClient`).

All 4 endpoints are `POST /api/Invoice/{action}`: `generate-xml`, `generate-signed`, `send`, `validate`.

## Critical conventions

- **API does not calculate IGV/ISC** — the frontend sends all computed amounts per item
- **XML encoding must be ISO-8859-1** (SUNAT requirement, set in XmlDeclaration)
- **Signature: RSA-SHA1, C14N, enveloped** — SUNAT does not support SHA256
- **HTTPS handled by reverse proxy** — the app runs HTTP-only
- **JSON camelCase** — configured via `JsonNamingPolicy.CamelCase`
- **Certificate loaded in controller constructor** (not DI), with fallback paths: `AppContext.BaseDirectory` → relative → `CurrentDirectory`
- **Config keys** in `appsettings.json`: `Sunat:OseUrl`, `Sunat:Ruc`, `Sunat:Usuario`, `Sunat:Password`, `Certificate:Path`, `Certificate:Password`
- **Docker** overrides `Certificate__Path` to `certs/test-cert.pfx` (double underscore for nested config)
- **Test cert** `certs/test-cert.pfx` (password `12345`) — self-signed, beta only
- **InvoiceResponse** uses Spanish field names: `Exitoso`, `Mensaje`, `XmlFirmado`, `XmlBase64`, `SerieNumero`, `HashFirma`, `EnvioSunat`

## SUNAT OSE beta

Default OSE URL: `https://e-beta.sunat.gob.pe/ol-ti-itcpfegem-beta/billService`
Credentials in config are the public SUNAT demo credentials (`MODDATOS`/`moddatos`). Production requires real SOL credentials and a registered certificate.
