using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CRM.Infrastructure.Contexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService = null!) : DbContext(options)
    {
        private readonly ICurrentUserService _currentUserService = currentUserService;

        public DbSet<User> Users { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<Company>().HasQueryFilter(c => c.OrganizationId == _currentUserService.GetOrganizationId() && !c.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<IBaseEntity>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);

            foreach(var entry in entries)
            {
                if(_currentUserService.IsAuthenticated())
                {
                    if(entry.State == EntityState.Added)
                    {
                        entry.Entity.CreatedAt = DateTime.Now;
                        entry.Entity.CreatedById = _currentUserService.GetCurrentUserId();
                        entry.Entity.OrganizationId = _currentUserService.GetOrganizationId();
                    }
                    if(entry.State == EntityState.Modified)
                    {
                        entry.Entity.UpdatedAt = DateTime.Now;
                        entry.Entity.UpdatedById = _currentUserService.GetCurrentUserId();
                    }
                    if(entry.State == EntityState.Deleted)
                    {
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        entry.Entity.DeletedAt = DateTime.Now;
                        entry.Entity.DeletedById = _currentUserService.GetCurrentUserId();
                    }
                }

            }

            return base.SaveChangesAsync(cancellationToken);


        }



    }
}
