using CRM.Application.Repositories;
using CRM.Application.Responses;
using CRM.Domain.Entities.Commons;
using CRM.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRM.Infrastructure.Repositories
{
    public class Repository<T, TKey>(ApplicationDbContext context) : IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        private readonly ApplicationDbContext _context = context;

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? expression = null)
        {
            return expression is null ?
                await _context.Set<T>().CountAsync() :
                await _context.Set<T>().CountAsync(expression);
        }

        public void Delete(TKey id)
        {
            var entity = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity!);
        }

        public async Task<PagedResult<T>?> GetAllAsync(int page, int pageSize, Expression<Func<T, bool>>? expression = null, List<Expression<Func<T, object>>>? includes = null)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable().AsNoTracking();

            if(includes != null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (expression != null)
                query = query.Where(expression);

            var data = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedResult<T>(data, page, pageSize, await CountAsync());
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, List<Expression<Func<T, object>>>? includes = null)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable().AsNoTracking();
            if(includes != null)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(expression);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
