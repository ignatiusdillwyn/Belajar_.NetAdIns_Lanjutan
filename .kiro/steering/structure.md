# CineBook - Arsitektur & Struktur Proyek

Ikuti aturan berikut PERSIS. Jangan menyimpang tanpa diminta.

## Layered Architecture (4 Lapis)

```
Controller  →  IService  →  IRepository<T>  →  DbContext
```

1. **Controller** hanya boleh memanggil method dari `IService` yang di-inject via constructor. Controller **TIDAK PERNAH** mengakses `DbContext` secara langsung.
2. **Service** memegang seluruh business logic (validasi, aturan bisnis, orkestrasi). Service memanggil `IRepository<T>` untuk operasi data.
3. **Repository bersifat GENERIC** — satu class `Repository<T>` untuk semua entity, diakses melalui `IRepository<T>`. **JANGAN** membuat repository spesifik per entity (mis. `MovieRepository`, `BookingRepository`).
4. **Repository HANYA berisi operasi data generik** (`Get`, `GetAll`, `Add`, `Update`, `Delete`, `SaveChanges`). **JANGAN** menaruh business logic di Repository.
5. `DbContext` hanya diakses dari Repository.

## Aturan Persistensi
- `SaveChanges()` / `SaveChangesAsync()` **HANYA** boleh dipanggil dari dalam **Service**.
- **JANGAN** memanggil `SaveChanges` dari Controller.
- **JANGAN** memanggil `SaveChanges` otomatis di dalam method Repository lain (mis. `Add`, `Update`, `Delete` tidak boleh SaveChanges sendiri).

## Dependency Injection
- Semua service didaftarkan di `Program.cs` lewat **interface**-nya:
  `services.AddScoped<IXxxService, XxxService>();`
- Sama untuk repository: `services.AddScoped(typeof(IRepository<>), typeof(Repository<>));`
- **JANGAN** mendaftarkan class konkret langsung tanpa interface.

## DTO
- **Semua** request/response body di Controller memakai **DTO**.
- **JANGAN** mengekspos entity `CineBook.Models` langsung ke client.
- Property DTO memakai **camelCase otomatis** dari serializer default. **JANGAN** menambahkan `JsonNamingPolicy` custom, dan **JANGAN** memakai snake_case.

## Namespace & Folder
- `CineBook.Models` — entity di folder `Models/`
- `CineBook.Data` — `DbContext` di folder `Data/`
- `CineBook.Repositories` — di folder `Repositories/`
- `CineBook.Services` — di folder `Services/`
- `CineBook.DTOs` — di folder `DTOs/`
- `CineBook.Controllers` — di folder `Controllers/`

## Autentikasi (Di Luar Cakupan)
- Endpoint `POST /api/auth/login` **TIDAK** dibuat.
- Atribut `[Authorize]` dan konfigurasi JWT **TIDAK** dipasang.
- `UserId` pada pembuatan Booking di-**hardcode = 1** dengan komentar `TODO` yang menerangkan akan diganti dari token JWT nanti.

## Migration & Seeding
- **DILARANG** memakai `HasData` atau seeding otomatis apapun di `OnModelCreating` maupun di dalam file migration.
- `OnModelCreating` **HANYA** berisi konfigurasi relasi antar entity (Fluent API `HasOne/WithMany/HasForeignKey`), unique index, dan konversi tipe data (mis. enum → string).
- Database sengaja dibiarkan **kosong** setelah `database update`. Data uji dimasukkan manual via `seed-data-manual.sql`.

## Cara Kerja Kolaborasi
Prompt akan diberikan bertahap per layer (Models → Data → Repositories → Services → DTOs → Controllers → Program.cs). Ikuti struktur dan **signature method** yang diberikan **PERSIS**:
- Jangan mengganti nama method.
- Jangan menambah/mengurangi parameter tanpa diminta.
- Jangan mengubah nama field, tipe data, atau atribut entity dari yang diberikan.
