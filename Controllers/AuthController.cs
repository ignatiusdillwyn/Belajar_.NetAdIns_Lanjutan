using Microsoft.AspNetCore.Mvc;
using CineBook.Services;
using CineBook.DTOs;
using Microsoft.AspNetCore.Mvc;
using Cinebook.Services;
using Cinebook.DTOs;

namespace Cinebook.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            LoginResponse? result = await _authService.LoginAsync(loginRequest);
            if (result == null)
            {
                return Unauthorized(
                    new { status = "error", message = "Email atau Password salah" }
                    );
            }
            return Ok(result);
        }
    }
}
