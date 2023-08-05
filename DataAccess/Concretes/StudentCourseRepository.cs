using Core.DataAccess.EntityFramework;
using Core.Entities.Relationships;
using DataAccess.Abstracts;
using DataAccess.Context;

namespace DataAccess.Concretes
{
    public class StudentCourseRepository : EfBaseRepository<StudentCourse, AppDbContext>, IStudentCourseRepository
    {
        public StudentCourseRepository(AppDbContext context) : base(context)
        {
        }
    }
}
