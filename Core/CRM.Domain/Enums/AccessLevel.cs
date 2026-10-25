using Ardalis.SmartEnum;

namespace CRM.Domain.Enums
{
    public sealed class AccessLevel : SmartEnum<AccessLevel>
    {
        public static readonly AccessLevel Public = new AccessLevel(nameof(Public), 1);
        public static readonly AccessLevel Private = new AccessLevel(nameof(Private), 2);
        

        private AccessLevel(string name, int value) : base(name, value)
        {

        }
    }
}
