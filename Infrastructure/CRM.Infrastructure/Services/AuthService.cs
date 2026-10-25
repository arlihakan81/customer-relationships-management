using CRM.Application.Interfaces;
using CRM.Application.Requests;
using CRM.Application.Responses;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Services
{
    public class AuthService(ApplicationDbContext context, ITokenService tokenService) : IAuthService
    {
        private readonly ApplicationDbContext _context = context;
        private readonly ITokenService _tokenService = tokenService;


        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Set<User>().Include(u => u.Role).FirstOrDefaultAsync(u => u.Email.Value == email);
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await GetByEmailAsync(request.Email);

            if (user is null)
            {
                return new LoginResponse
                {
                    Success = false,
                    Error = "Bu e-posta adresiyle ilişkili kullanıcı bulunamadı"
                };
            }
            
            if(user.IsDeleted)
            {
                return new LoginResponse
                {
                    Success = false,
                    Error = "Bu e-posta adresiyle ilişkili hesap silinmiş ya da devre dışı bırakılmış"
                };
            }

            bool isSuccess = new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password)
                == PasswordVerificationResult.Success;

            if (!isSuccess)
            {
                return new LoginResponse
                {
                    Success = false,
                    Error = "E-posta adresi ve parola eşleşmiyor"
                };
            }

            var token = _tokenService.GenerateToken(user);

            return new LoginResponse
            {
                Success = true,
                AccessToken = token
            };

        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            var user = await GetByEmailAsync(request.Email);

            if(user is not null && !user.IsDeleted)
            {
                return new RegisterResponse
                {
                    Success = false,
                    Message = "Bu e-posta adresi zaten kayıtlı başka bir e-posta hesabıyla tekrar deneyin",
                    Error = "Mevcut e-posta adresi"
                };
            }

            var organization = new Organization
            {
                Name = request.OrganizationName,
                Users = [
                    new User {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Email = new Domain.ValueObjects.EmailAddress(request.Email),
                        PasswordHash = new PasswordHasher<User>().HashPassword(null!, request.Password),
                        RoleId = _context.Roles.FirstOrDefault(r => r.Name == "Organization Admin")!.Id
                    }
                    ]
            };

            await _context.Organizations.AddAsync(organization);
            await _context.SaveChangesAsync();

            return new RegisterResponse
            {
                Success = true,
                Message = "Kayıt Başarılı! "
            };



        }
    }
}
