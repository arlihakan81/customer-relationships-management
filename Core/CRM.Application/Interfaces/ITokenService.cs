using CRM.Domain.Entities;
using System.Security.Claims;

namespace CRM.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);

        List<Claim> GetClaims(User user);
    }
}
