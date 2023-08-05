using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstracts;
using DataAccess.Context;

namespace DataAccess.Concretes;

public class StudentRepository : EfRepositoryBase<Student, AppDbContext>, IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public ICollection<Student> GetStudents()
    {
        return _context.Students.OrderBy(s => s.Id).ToList();
    }


}