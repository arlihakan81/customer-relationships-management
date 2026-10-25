using CRM.Domain.Entities.Commons;
using CRM.Domain.Enums;
using CRM.Domain.ValueObjects;

namespace CRM.Domain.Entities
{
    public class Company : BaseEntity<Guid>
    {
        public override Guid Id { get; set; } = Guid.CreateVersion7();
        public override Guid? CreatedById { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override Guid? OrganizationId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Name { get; set; } = string.Empty;

        public EmailAddress? EmailAddress { get; set; }
        public Address? Address { get; set; }
        public string? Website { get; set; }
        public PhoneNumber? Fax { get; set; }
        public int? NoOfEmployees { get; set; }

        public decimal? AnnualRevenue { get; set; }
        public PhoneNumber? Phone { get; set; }

        public PhoneNumber? Phone2 { get; set; }

        public SocialProfiles? SocialProfiles { get; set; }


        public AccessLevel AccessLevel { get; set; } = AccessLevel.Public;



    }
}
