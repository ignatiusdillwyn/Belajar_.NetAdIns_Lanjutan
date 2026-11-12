using CineBook.DTOs;
using CineBook.Models;
using CineBook.Repositories;

namespace CineBook.Services
{
    public class TheaterService : ITheaterService
    {
        private readonly IRepository<Theater> _theaterRepository;

        public TheaterService(IRepository<Theater> theaterRepository)
        {
            _theaterRepository = theaterRepository;
        }

        public async Task<List<TheaterResponse>> GetAllAsync()
        {
            List<Theater> theaters = await _theaterRepository.GetAllAsync();
            return theaters.Select(ToResponse).ToList();
        }

        public async Task<TheaterResponse?> GetByIdAsync(long id)
        {
            Theater? theater = await _theaterRepository.GetByIdAsync(id);
            return theater != null ? ToResponse(theater) : null;
        }

        public async Task<TheaterResponse> CreateAsync(TheaterRequest request)
        {
            var theater = new Theater
            {
                Name = request.Name,
                Location = request.Location
            };

            await _theaterRepository.AddAsync(theater);
            await _theaterRepository.SaveChangesAsync();
            return ToResponse(theater);
        }

        public async Task<TheaterResponse?> UpdateAsync(long id, TheaterRequest request)
        {
            Theater? theater = await _theaterRepository.GetByIdAsync(id);
            if (theater == null) return null;

            theater.Name = request.Name;
            theater.Location = request.Location;

            _theaterRepository.Update(theater);
            await _theaterRepository.SaveChangesAsync();
            return ToResponse(theater);
        }

        public async Task<bool?> DeleteAsync(long id)
        {
            // JELASKAN: include "Schedules" supaya kita bisa
            // mengecek apakah Theater masih dipakai jadwal.
            Theater? theater = await _theaterRepository.GetByIdAsync(id, "Schedules");
            if (theater == null) return null;
            if (theater.Schedules.Any()) return false;

            _theaterRepository.Delete(theater);
            await _theaterRepository.SaveChangesAsync();
            return true;
        }

        private static TheaterResponse ToResponse(Theater theater)
        {
            return new TheaterResponse
            {
                Id = theater.Id,
                Name = theater.Name,
                Location = theater.Location
            };
        }
    }
}
