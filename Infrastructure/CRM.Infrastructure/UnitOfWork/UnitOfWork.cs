using CRM.Application.Repositories;
using CRM.Application.UnitOfWork;
using CRM.Domain.Entities;
using CRM.Infrastructure.Contexts;

namespace CRM.Infrastructure.UnitOfWork
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;

        public IRepository<Company, Guid> CompanyRepository { get; set; }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
