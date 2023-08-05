
using Core.Entities.Relationships;

namespace Core.Entities
{
    public class Student : AbsBaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; } // One-to-many ilişkisi

        public ICollection<StudentCourse> StudentCourses { get; set; } // Many-to-many ilişkisi
    }
}
