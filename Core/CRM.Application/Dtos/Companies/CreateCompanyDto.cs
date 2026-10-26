using CRM.Domain.Enums;
using CRM.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Dtos.Companies
{
    public class CreateCompanyDto
    {
        [Required]
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
