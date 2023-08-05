namespace Core.DataAccess.Abstracts;

public interface IQuery<TEntity>
{
    IQueryable<TEntity> Query();
}