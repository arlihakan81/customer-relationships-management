namespace CRM.Domain.ValueObjects
{
    public class Address : IEquatable<Address>
    {
        public string? AddressLine1 { get; init; }
        public string? AddressLine2 { get; init; }
        public string? City { get; init; }
        public string? Region { get; init; }
        public string? Country { get; init; }
        public string? PostalCode { get; init; }

        public Address(string? addressLine1, string? addressLine2, string? city, string? region, string? country, string? postalCode)
        {
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            Region = region;
            Country = country;
            PostalCode = postalCode;
        }

        public bool Equals(Address? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return AddressLine1 == other.AddressLine1 &&
                   AddressLine2 == other.AddressLine2 &&
                   City == other.City &&
                   Region == other.Region &&
                   Country == other.Country &&
                   PostalCode == other.PostalCode;
        }

        public override bool Equals(object? obj) => Equals(obj as Address);

        public override int GetHashCode()
        {
            return HashCode.Combine(AddressLine1, AddressLine2, City, Region, Country, PostalCode);
        }
    }
}
