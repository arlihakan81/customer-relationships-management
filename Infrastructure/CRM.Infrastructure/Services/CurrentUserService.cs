using CRM.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CRM.Infrastructure.Services
{
    public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;


        public Guid? GetCurrentUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            return Guid.TryParse(userIdClaim, out Guid userId) ? userId : null;
        }

        public string GetCurrentUserRole()
        {
            var userRole = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            return userRole;
        }

        public Guid? GetOrganizationId()
        {
            var orgIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "OrganizationId")?.Value;
            return Guid.TryParse(orgIdClaim, out Guid orgId) ? orgId : null;
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
