using System.Linq.Expressions;
using Core.Dtos;
using Core.Entities;

namespace Core.DataAccess.Abstracts;

public interface IAsyncRepository<T> : IQuery<T> where T : AbsBaseEntity
{
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
}