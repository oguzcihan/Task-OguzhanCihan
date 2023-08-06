using Core.DataAccess.Abstracts;
using Core.Dtos.Responses;
using Core.Entities;

namespace DataAccess.Abstracts;

public interface IStudentRepository : IBaseRepository<Student>
{
    IEnumerable<StudentResponse> GetStudentsWithCourses();
    StudentResponse GetStudentWithCourses(int studentId);


}