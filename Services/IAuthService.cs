using CineBook.Models;
using Cinebook.DTOs;

namespace Cinebook.Services
{
    public interface IAuthService
    {
        Task<LoginResponse?> LoginAsync(LoginRequest loginRequest);

    }
}
