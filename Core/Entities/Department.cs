

namespace Core.Entities
{
    public class Department:AbsBaseEntity
    {
        public string DepartmentName { get; set; }

        public ICollection<Student> Students { get; set; } // One-to-many ilişkisi
    }
}
