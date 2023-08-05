using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess.Abstracts;

public interface IRepository<T> : IQuery<T> where T : AbsBaseEntity
{
    T Get(Expression<Func<T, bool>> predicate);
    IList<T> GetList(Expression<Func<T, bool>> filter = null);
    
    T Add(T entity);
    T Update(T entity);
    T Delete(T entity);

}