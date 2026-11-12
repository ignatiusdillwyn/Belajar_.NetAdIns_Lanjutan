# CineBook - Tech Stack

## Runtime & Framework
- **ASP.NET Core Web API** dengan target `net8.0`.
- **C#** dengan `Nullable` enabled dan `ImplicitUsings` enabled (default template `dotnet new webapi`).

## Data Layer
- **Entity Framework Core 8** sebagai ORM.
- **PostgreSQL** sebagai database, diakses via provider **Npgsql**.

## NuGet Packages Wajib (versi 8.x)
- `Microsoft.EntityFrameworkCore`
- `Npgsql.EntityFrameworkCore.PostgreSQL`
- `Microsoft.EntityFrameworkCore.Tools`

Jangan tambahkan package lain (misalnya AutoMapper, FluentValidation, MediatR, dsb.) kecuali diminta eksplisit.

## Konfigurasi
- Connection string berada di `appsettings.json` dengan key `ConnectionStrings:CineBook`.
- Format host default: `Host=localhost;Database=CineBookDb;Username=postgres;Password=...;`.

## JSON Serialization
- Gunakan **default ASP.NET Core** (camelCase otomatis).
- **JANGAN** menambahkan konfigurasi `JsonNamingPolicy` (mis. ke snake_case) atau setup serialization kustom apapun.

## Migration & Seeding
- Migration dibuat lewat CLI EF Core (`dotnet ef migrations add ...`, `dotnet ef database update`).
- **DILARANG** memakai `HasData` atau seeding otomatis di `OnModelCreating` maupun di dalam migration.
- Data uji dimasukkan manual via SQL script terpisah setelah `database update`.

## Perintah Umum (cmd/PowerShell di Windows)
- Build: `dotnet build`
- Run: `dotnet run`
- Tambah migration: `dotnet ef migrations add <Nama>`
- Apply migration: `dotnet ef database update`
