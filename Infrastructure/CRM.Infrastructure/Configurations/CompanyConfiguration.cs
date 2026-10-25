using CRM.Domain.Entities;
using CRM.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.CreatedBy)
                .WithMany()
                .HasForeignKey(c => c.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.UpdatedBy)
                .WithMany()
                .HasForeignKey(c => c.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.DeletedBy)
                .WithMany()
                .HasForeignKey(c => c.DeletedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.OrganizationId).IsRequired();

            builder.OwnsOne(c => c.EmailAddress, email =>
            {
                email.Property(e => e.Value).HasColumnName("Email").HasColumnType("nvarchar(255)").IsRequired();
            });

            builder.OwnsOne(c => c.Address, address =>
            {
                address.Property(c => c.AddressLine1).HasColumnName("AddressLine1").HasColumnType("nvarchar(255)").IsRequired();
                address.Property(c => c.AddressLine2).HasColumnName("AddressLine2").HasColumnType("nvarchar(255)");
                address.Property(c => c.City).HasColumnName("City").HasColumnType("nvarchar(100)").IsRequired();
                address.Property(c => c.Region).HasColumnName("Region").HasColumnType("nvarchar(100)");
                address.Property(c => c.Country).HasColumnName("Country").HasColumnType("nvarchar(100)").IsRequired();
                address.Property(c => c.PostalCode).HasColumnName("PostalCode").HasColumnType("nvarchar(10)").IsRequired();
            });

            builder.OwnsOne(c => c.SocialProfiles, social =>
            {
                social.Property(s => s.Linkedin).HasColumnName("Linkedin_Url").HasColumnType("nvarchar(255)");
                social.Property(s => s.Facebook).HasColumnName("Facebook_Url").HasColumnType("nvarchar(255)");
                social.Property(s => s.Instagram).HasColumnName("Instragram_Url").HasColumnType("nvarchar(255)");
                social.Property(s => s.Youtube).HasColumnName("Youtube_Url").HasColumnType("nvarchar(255)");
            });

            builder.OwnsOne(c => c.Phone, phone =>
            {
                phone.Property(p => p.CountryCode).HasColumnName("Phone_CountryCode").HasColumnType("nvarchar(5)").IsRequired(false);
                phone.Property(p => p.Value).HasColumnName("Phone").HasColumnType("nvarchar(10)").IsRequired(false);
            });

            builder.OwnsOne(c => c.Phone2, phone2 =>
            {
                phone2.Property(p => p.CountryCode).HasColumnName("Phone2_CountryCode").HasColumnType("nvarchar(5)").IsRequired(false);
                phone2.Property(p => p.Value).HasColumnName("Phone2").HasColumnType("nvarchar(10)").IsRequired(false);
            });

            builder.OwnsOne(c => c.Fax, fax =>
            {
                fax.Property(p => p.CountryCode).HasColumnName("Fax_CountryCode").HasColumnType("nvarchar(5)").IsRequired(false);
                fax.Property(p => p.Value).HasColumnName("Fax").HasColumnType("nvarchar(10)").IsRequired(false);
            });

            builder.Property(c => c.AccessLevel)
                .HasConversion(access => access.Name, name => AccessLevel.FromName(name, false)).HasMaxLength(50).IsRequired();
        }
    }
}
