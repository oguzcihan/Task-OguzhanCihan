using Core.Entities.Relationships;

namespace Core.Entities
{
    public class Course : AbsBaseEntity
    {
        public string CourseName { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; } // Many-to-many ilişkisi
    }
}
