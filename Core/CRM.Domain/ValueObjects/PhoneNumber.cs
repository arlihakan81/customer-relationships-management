using CRM.Domain.Models;

namespace CRM.Domain.ValueObjects
{
    public class PhoneNumber : IEquatable<PhoneNumber>
    {
        public string? CountryCode { get; set; }
        public string? Value { get; set; }

        public PhoneNumber(string countryCode, string value)
        {
            if (string.IsNullOrEmpty(countryCode))
                throw new ErrorModel("Ülke kodu boş olamaz");
            if (string.IsNullOrEmpty(value))
                throw new ErrorModel("Telefon numarası boş olamaz!");
            // Basit bir telefon numarası doğrulama örneği
            if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d{10,15}$"))
                throw new ErrorModel("Telefon numarası geçerli bir formatta olmalıdır.");
            CountryCode = countryCode;
            Value = value;
        }


        public bool Equals(PhoneNumber? other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other)) return true;
            return CountryCode == other.CountryCode &&
                Value == other.Value;
        }

        public override bool Equals(object? obj) => Equals(obj as PhoneNumber);

        public override int GetHashCode() => HashCode.Combine(CountryCode, Value).GetHashCode();
        

    }
}
