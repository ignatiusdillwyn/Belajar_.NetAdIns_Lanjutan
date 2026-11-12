using CineBook.DTOs;

namespace CineBook.Services
{
    public interface ITheaterService
    {
        Task<List<TheaterResponse>> GetAllAsync();
        Task<TheaterResponse?> GetByIdAsync(long id);
        Task<TheaterResponse> CreateAsync(TheaterRequest request);
        Task<TheaterResponse?> UpdateAsync(long id, TheaterRequest request);

        // JELASKAN: null = Theater tidak ditemukan,
        // false = ditolak karena masih punya jadwal,
        // true = berhasil dihapus.
        Task<bool?> DeleteAsync(long id);
    }
}
