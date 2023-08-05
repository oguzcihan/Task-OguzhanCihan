using System.Linq.Expressions;

namespace Core.DataAccess.Abstracts
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        IQueryable<TEntity> GetAll();

        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

    
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
