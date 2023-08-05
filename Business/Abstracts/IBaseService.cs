using Core.Dtos;
using Core.Entities;
using System.Linq.Expressions;

namespace Business.Abstracts
{
    public interface IBaseService<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
      
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity); //update in ef core tarafında async methodları yok
        Task RemoveAsync(T entity);

        Task RemoveRangeAsync(IEnumerable<T> entities);

        T GetById(int id);
        List<T> GetAll();
        

    }
}
