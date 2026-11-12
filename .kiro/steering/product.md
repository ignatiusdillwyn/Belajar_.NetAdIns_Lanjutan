# CineBook - Product

## Ringkasan
CineBook adalah REST API untuk sistem pemesanan tiket bioskop. Klien dapat menjelajah daftar film, jadwal tayang di theater, memilih kursi yang tersedia, dan membuat booking dengan status PENDING/SUCCESS/CANCELLED.

## Domain Utama
- **Movie** — informasi film (judul, deskripsi, durasi).
- **Theater** — bioskop/studio dengan nama dan lokasi.
- **Schedule** — jadwal tayang film di theater tertentu, dengan waktu mulai dan harga.
- **Seat** — kursi per Schedule, memiliki nomor kursi dan flag ketersediaan.
- **Booking** — transaksi pemesanan oleh user untuk satu Schedule; berisi total tiket, total harga, dan status.
- **BookingSeat** — pivot antara Booking dan Seat (banyak kursi per booking).
- **User** — akun pemesan (Email unik, Nama, Password).

## Cakupan & Batasan Fungsional
- **Autentikasi TIDAK termasuk cakupan proyek ini.** Endpoint `POST /api/auth/login` dan atribut `[Authorize]` tidak dibuat.
- Selama JWT belum ada, `UserId` pada pembuatan Booking di-**hardcode = 1** dengan komentar `TODO` yang menandai ini akan diganti dengan claim dari token JWT nanti.
- Password disimpan sebagai string biasa di kolom (placeholder). Hashing bukan bagian dari cakupan saat ini.

## Data Uji
Setelah migration dijalankan, database sengaja **kosong**. Data uji untuk testing diisi manual lewat file SQL terpisah (`seed-data-manual.sql`) yang dijalankan via pgAdmin/psql. **Tidak** ada seeding otomatis di migration atau `OnModelCreating`.
