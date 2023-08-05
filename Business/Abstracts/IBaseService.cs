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
  
    }
}
