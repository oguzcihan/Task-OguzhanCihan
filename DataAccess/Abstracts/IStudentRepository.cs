using Core.DataAccess.Abstracts;
using Core.Dtos;
using Core.Entities;
using DataAccess.Context;
using System.Linq.Expressions;

namespace DataAccess.Abstracts;

public interface IStudentRepository : IAsyncRepository<Student>, IRepository<Student>
{
    Task<bool> AnyAsync(Expression<Func<StudentDto, bool>> expression);
    ICollection<Student> GetStudents();
}