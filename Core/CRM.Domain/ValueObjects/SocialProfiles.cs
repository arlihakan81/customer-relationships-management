using CRM.Domain.Models;

namespace CRM.Domain.ValueObjects
{
    public class SocialProfiles : IEquatable<SocialProfiles>
    {
        public string? Linkedin { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Youtube { get; set; }

        public SocialProfiles(string? linkedin, string? facebook, string? instagram, string? youtube)
        {
            if(!string.IsNullOrEmpty(linkedin))
            {
                if(!linkedin.Contains("linkedin.com", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ErrorModel("Geçerli bir linkedin URL'si girmelisiniz");
                }
            }

            if (!string.IsNullOrEmpty(facebook))
            {
                if (!facebook.Contains("facebook.com", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ErrorModel("Geçerli bir facebook URL'si girmelisiniz");
                }
            }

            if (!string.IsNullOrEmpty(instagram))
            {
                if (!instagram.Contains("instagram.com", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ErrorModel("Geçerli bir instagram URL'si girmelisiniz");
                }
            }

            if (!string.IsNullOrEmpty(youtube))
            {
                if (!youtube.Contains("youtube.com", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ErrorModel("Geçerli bir youtube URL'si girmelisiniz");
                }
            }

            Linkedin = linkedin;
            Facebook = facebook;
            Instagram = instagram;
            Youtube = youtube;
        }

        public bool Equals(SocialProfiles? other)
        {
            if (other is null) return false;

            if(ReferenceEquals(this, other))
                return true;




            return Linkedin == other.Linkedin && Facebook == other.Facebook && Instagram == other.Instagram && Youtube == other.Youtube;

        }

        public override bool Equals(object? obj) => Equals(obj as SocialProfiles);

        public override int GetHashCode() => HashCode.Combine(Linkedin,Facebook,Instagram, Youtube);
        



    }
}
