using CRM.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace CRM.Application.Requests
{
    public class RegisterRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string OrganizationName { get; set; } = string.Empty;


    }
}
