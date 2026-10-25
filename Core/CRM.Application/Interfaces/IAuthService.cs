using CRM.Application.Requests;
using CRM.Application.Responses;
using CRM.Domain.Entities;

namespace CRM.Application.Interfaces
{
    public interface IAuthService
    {
        Task<User?> GetByEmailAsync(string email);

        Task<LoginResponse> LoginAsync(LoginRequest request);

        Task<RegisterResponse> RegisterAsync(RegisterRequest request);

    }
}
