using Core.DataAccess.EntityFramework;
using Core.Dtos.Responses;
using Core.Entities;
using DataAccess.Abstracts;
using DataAccess.Context;

namespace DataAccess.Concretes;

public class StudentRepository : EfBaseRepository<Student, AppDbContext>, IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<StudentResponse> GetStudentsWithCourses()
    {
        //iki tablo join edildi

        var result = from student in _context.Students
                     join department in _context.Departments on student.DepartmentId equals department.Id
                     where student.StudentCourses.Any()
                     select new StudentResponse
                     {
                         Name = student.Name,
                         Age = student.Age,
                         DepartmentName = department.DepartmentName,
                         CoursesName = student.StudentCourses.Select(sc => sc.Course.CourseName).ToList()
                     };

        return result.ToList();

    }

    public StudentResponse GetStudentWithCourses(int studentId)
    {
        var result = from department in _context.Departments
                     join studentCourse in _context.StudentCourses on studentId equals studentCourse.StudentId
                     join course in _context.Courses on studentCourse.CourseId equals course.Id
                     where studentId == studentCourse.StudentId
                     select new StudentResponse
                     {
                         Name = _context.Students.FirstOrDefault(s => s.Id == studentId).Name,
                         Age = _context.Students.FirstOrDefault(s => s.Id == studentId).Age,
                         DepartmentName = department.DepartmentName,
                         CoursesName = _context.StudentCourses
                                          .Where(sc => sc.StudentId == studentId)
                                          .Select(sc => sc.Course.CourseName)
                                          .ToList()
                     };

        return result.FirstOrDefault();
    }
}