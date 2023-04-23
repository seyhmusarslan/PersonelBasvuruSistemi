using System;
using Domain.Common;
using System.Linq.Expressions;

namespace Application.Interfaces.Repositories
{
    public interface IRepositoryAsync<T> where T : BaseEntity
    {
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<IReadOnlyList<T>> ListAsync(Expression<Func<T,bool>> expression,Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
            string includeProperties = "");
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        
    }
}
