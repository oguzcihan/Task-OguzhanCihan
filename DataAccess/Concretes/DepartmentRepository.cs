using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstracts;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes;

public class DepartmentRepository : EfBaseRepository<Department, AppDbContext>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Department> GetSingleDepartmentByIdWithStudentAsync(int departmentId)
    {
        return await _context.Departments.Include(x => x.Students).Where(x => x.Id == departmentId).SingleOrDefaultAsync();
    }
}