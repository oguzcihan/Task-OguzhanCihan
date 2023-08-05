using Core.DataAccess.Abstracts;
using Core.Entities;

namespace DataAccess.Abstracts;

public interface IStudentRepository : IBaseRepository<Student>
{
    ICollection<Student> GetStudents();
}