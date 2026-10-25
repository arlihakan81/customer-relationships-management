using CRM.Domain.ValueObjects;

namespace CRM.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Name => $"{FirstName}{LastName}_{Id.ToString()[..8]}";

        public EmailAddress Email { get; set; }

        public bool IsDeleted { get; set; } = false;

        public bool IsEmailConfirmed { get; set; } = false;

        public string PasswordHash { get; set; } = string.Empty;

        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = default!;

        public Guid? OrganizationId { get; set; }

        public virtual Organization? Organization { get; set; }



    }
}
