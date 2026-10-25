using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.Value).HasColumnName("Email").HasColumnType("nvarchar(255)").IsRequired();
            });
                


        }
    }
}
