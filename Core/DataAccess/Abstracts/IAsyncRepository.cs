using System.Linq.Expressions;

namespace Core.DataAccess.Abstracts;

public interface IAsyncRepository<TEntity> : IQuery<TEntity> where TEntity : class
{
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);
}