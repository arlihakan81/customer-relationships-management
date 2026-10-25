using CRM.Domain.Entities;

namespace CRM.Application.Interfaces
{
    public interface ICurrentUserService
    {
        Guid? GetOrganizationId();
        Guid? GetCurrentUserId();

        string GetCurrentUserRole();

        bool IsAuthenticated();

    }
}
