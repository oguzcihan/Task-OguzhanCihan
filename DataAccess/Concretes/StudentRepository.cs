using Core.DataAccess.EntityFramework;
using Core.Dtos;
using Core.Entities;
using DataAccess.Abstracts;
using DataAccess.Context;
using System.Linq.Expressions;

namespace DataAccess.Concretes;

public class StudentRepository : EfBaseRepository<Student, AppDbContext>, IStudentRepository
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