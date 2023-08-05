using System.Linq.Expressions;

namespace Core.DataAccess.Abstracts
{
    public interface IBaseRepository<TEntity> : IRepository<TEntity>, IAsyncRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(int id);
    }
}
