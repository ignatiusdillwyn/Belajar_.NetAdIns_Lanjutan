using Microsoft.AspNetCore.Mvc;
using CineBook.DTOs;
using CineBook.Services;

namespace CineBook.Controllers
{
    [ApiController]
    [Route("api/theaters")]
    public class TheatersController : ControllerBase
    {
        private readonly ITheaterService _theaterService;

        public TheatersController(ITheaterService theaterService)
        {
            _theaterService = theaterService;
        }

        [HttpGet] // GET /api/theaters
        public async Task<IActionResult> GetTheaters()
        {
            var theaters = await _theaterService.GetAllAsync();
            return Ok(theaters);
        }

        [HttpGet("{id:long}")] // GET /api/theaters/{id}
        public async Task<IActionResult> GetTheater(long id)
        {
            var theater = await _theaterService.GetByIdAsync(id);
            if (theater == null) return NotFound();
            return Ok(theater);
        }

        [HttpPost] // POST /api/theaters
        public async Task<IActionResult> CreateTheater([FromBody] TheaterRequest request)
        {
            var created = await _theaterService.CreateAsync(request);
            return Created($"/api/theaters/{created.Id}", created);
        }

        [HttpPut("{id:long}")] // PUT /api/theaters/{id}
        public async Task<IActionResult> UpdateTheater(long id, [FromBody] TheaterRequest request)
        {
            var updated = await _theaterService.UpdateAsync(id, request);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id:long}")] // DELETE /api/theaters/{id}
        public async Task<IActionResult> DeleteTheater(long id)
        {
            var result = await _theaterService.DeleteAsync(id);
            if (result == null) return NotFound();
            if (result == false)
                return Conflict(new { error = "Theater masih punya jadwal tayang, hapus jadwalnya dulu" });
            return NoContent();
        }
    }
}
