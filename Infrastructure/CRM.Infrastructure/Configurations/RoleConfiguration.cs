using CRM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(r => r.Id);

            builder.HasData([
                new Role {
                    Id = 1,
                    Name = "Super Admin",
                    IsSystemRole = true
                },
                new Role {
                    Id = 2,
                    Name = "Organization Admin",
                    IsSystemRole = false
                },
                new Role {
                    Id = 3,
                    Name = "Sales Manager",
                    IsSystemRole = false
                },
                new Role {
                    Id = 4,
                    Name = "Sales Rep",
                    IsSystemRole = false
                }
                ]);



        }
    }
}
