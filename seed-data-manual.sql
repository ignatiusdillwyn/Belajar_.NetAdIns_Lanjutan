-- Script SQL data uji CineBook.
-- CATATAN: File ini TIDAK dieksekusi oleh aplikasi. Jalankan MANUAL lewat
-- pgAdmin/psql SETELAH `dotnet ef database update` selesai (Prompt 8).
-- JANGAN masukkan isi ini ke dalam migration atau OnModelCreating.

INSERT INTO "Movies" ("Id", "Title", "Description", "Duration") VALUES
(1, 'Inception', 'Pencuri mimpi.', 148),
(2, 'Interstellar', 'Perjalanan antar galaksi.', 169);

INSERT INTO "Theaters" ("Id", "Name", "Location") VALUES
(1, 'Studio 1 Premium', 'Lantai 3');

INSERT INTO "Schedules" ("Id", "MovieId", "TheaterId", "StartTime", "Price") VALUES
(1, 1, 1, '2026-07-10 19:00:00', 75000);

INSERT INTO "Seats" ("Id", "ScheduleId", "SeatNumber", "IsAvailable") VALUES
(1, 1, 'A1', true), (2, 1, 'A2', true), (3, 1, 'A3', true),
(4, 1, 'A4', true), (5, 1, 'A5', true), (6, 1, 'A6', true),
(7, 1, 'A7', true), (8, 1, 'A8', true), (9, 1, 'A9', true), (10, 1, 'A10', true);

INSERT INTO "Users" ("Id", "Email", "Password", "Nama") VALUES
(1, 'test@cinebook.com', 'hashed-password-placeholder', 'Test User');
