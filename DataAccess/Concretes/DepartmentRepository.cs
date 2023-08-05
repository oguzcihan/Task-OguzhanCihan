using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstracts;
using DataAccess.Context;

namespace DataAccess.Concretes;

public class DepartmentRepository : EfRepositoryBase<Department, AppDbContext>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext context) : base(context)
    {
    }
}