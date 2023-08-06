namespace Core.Dtos
{
    public class StudentDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public List<int> CourseIds { get; set; }
    }
}
