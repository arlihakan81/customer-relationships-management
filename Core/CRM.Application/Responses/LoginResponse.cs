namespace CRM.Application.Responses
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string? AccessToken { get; set; }
        public string? Error { get; set; }


    }
}
