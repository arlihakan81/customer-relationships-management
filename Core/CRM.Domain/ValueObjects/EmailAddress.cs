namespace CRM.Domain.ValueObjects
{
    public class EmailAddress : IEquatable<EmailAddress>
    {
        public string Value { get; init; }

        public EmailAddress()
        {
            
        }

        public EmailAddress(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("E-posta adresi boş olamaz.", nameof(value));

            // Burada ek format/regex kontrolleri de yapılabilir.

            Value = value;
        }

        public bool Equals(EmailAddress? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object? obj) => Equals(obj as EmailAddress);

        public override int GetHashCode() => StringComparer.OrdinalIgnoreCase.GetHashCode(Value);
    }
}
