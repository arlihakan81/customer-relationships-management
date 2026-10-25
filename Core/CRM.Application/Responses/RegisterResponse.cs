namespace CRM.Application.Responses
{
    public class RegisterResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;

        public string? Error { get; set; }

    }
}
