using Core.DataAccess.Abstracts;
using Core.Dtos.Responses;
using Core.Entities;

namespace DataAccess.Abstracts;

public interface IStudentRepository : IBaseRepository<Student>
{
    /// <summary>
    /// Students ve Courses listesini döner.
    /// </summary>
    /// <returns></returns>
    IEnumerable<StudentResponse> GetStudentsWithCourses();

    /// <summary>
    /// Student ve Courses listesini döner.
    /// </summary>
    /// <param name="studentId"></param>
    /// <returns></returns>
    StudentResponse GetStudentWithCourses(int studentId);


}