using CRM.Application.Responses;
using CRM.Domain.Entities.Commons;
using System.Linq.Expressions;

namespace CRM.Application.Repositories
{
    public interface IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        Task<PagedResult<T>?> GetAllAsync(int page, int pageSize, Expression<Func<T, bool>>? expression = null, List<Expression<Func<T, object>>>? includes = null);

        Task<T?> GetAsync(Expression<Func<T, bool>> expression, List<Expression<Func<T, object>>>? includes = null);

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(TKey id);

        Task<int> CountAsync(Expression<Func<T, bool>>? expression = null);

    }
}
