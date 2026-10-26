using CRM.Application.Repositories;
using CRM.Domain.Entities;

namespace CRM.Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        IRepository<Company, Guid> CompanyRepository { get; set; }



    }
}
