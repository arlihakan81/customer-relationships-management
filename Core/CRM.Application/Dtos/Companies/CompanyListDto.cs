using CRM.Domain.ValueObjects;

namespace CRM.Application.Dtos.Companies
{
    public class CompanyListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public EmailAddress EmailAddress { get; set; }




    }
}
