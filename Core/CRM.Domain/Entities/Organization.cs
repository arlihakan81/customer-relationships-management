using CRM.Domain.ValueObjects;

namespace CRM.Domain.Entities
{
    public class Organization
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();

        public string Name { get; set; } = string.Empty;

        public string? Domain { get; set; }

        public EmailAddress? EmailAddress { get; set; }

        public Address? Address { get; set; }

        public virtual ICollection<User>? Users { get; set; }

    }
}
