using System.Linq.Expressions;
using Core.DataAccess.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework;

public class EfBaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
    where TEntity : class
    where TContext : DbContext
{
    protected TContext Context { get; }
    //private readonly DbSet<TEntity> _dbSet;

    public EfBaseRepository(TContext context)
    {
        Context = context;
    }

    public IQueryable<TEntity> Query()
    {
        return Context.Set<TEntity>();
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Deleted;
        await Context.SaveChangesAsync();
        return entity;
    }

    public TEntity Get(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().FirstOrDefault(predicate);
    }

    public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
    {
        return filter == null ? Context.Set<TEntity>().ToList() : Context.Set<TEntity>().Where(filter).ToList();
    }

    public TEntity Add(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        Context.SaveChanges();
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        Context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Deleted;
        Context.SaveChanges();
        return entity;
    }

    public IQueryable<TEntity> GetAll()
    {
        //asnotracking memory e verileri almaz daha verimli çalışır
        return Context.Set<TEntity>().AsNoTracking().AsQueryable();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await Context.Set<TEntity>().FindAsync(id);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        Context.RemoveRange(entities);
        Context.SaveChanges();
    }

    
}