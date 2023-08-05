using System.Linq.Expressions;

namespace Core.DataAccess.Abstracts
{
    public interface IRepository<TEntity> : IQuery<TEntity> where TEntity : class
    {
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
    }
}