using Microsoft.AspNetCore.Mvc;
using CineBook.Services;

namespace CineBook.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies(
            [FromQuery] string? search,
            [FromQuery] int page = 1,
            [FromQuery] int limit = 10)
        {
            var movies = await _movieService.GetAllAsync(search, page, limit);
            return Ok(movies);
        }
    }
}
