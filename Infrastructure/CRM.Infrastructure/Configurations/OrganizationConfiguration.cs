using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations
{
    public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organizations");

            builder.HasKey(o => o.Id);

            builder.OwnsOne(o => o.EmailAddress, email =>
            {
                email.Property(e => e.Value).HasColumnName("Email").HasColumnType("nvarchar(255)");
            });

            builder.OwnsOne(o => o.Address, address =>
            {
                address.Property(a => a.AddressLine1).HasColumnName("AddressLine1").HasColumnType("nvarchar(255)").IsRequired().HasMaxLength(255);
                address.Property(a => a.AddressLine2).HasColumnName("AddressLine2").HasColumnType("nvarchar(255)").HasMaxLength(255);
                address.Property(a => a.City).HasColumnName("City").HasColumnType("nvarchar(100)").IsRequired();
                address.Property(a => a.Region).HasColumnName("Region").HasColumnType("nvarchar(100)");
                address.Property(a => a.Country).HasColumnName("Country").HasColumnType("nvarchar(100)").IsRequired();
                address.Property(a => a.PostalCode).HasColumnName("PostalCode").HasColumnType("nvarchar(10)").IsRequired();
            });


        }
    }
}
