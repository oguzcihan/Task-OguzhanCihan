namespace Core.Dtos.Responses
{
    public class StudentResponse
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string DepartmentName { get; set; }
        public IEnumerable<string> CoursesName { get; set; }
    }
}
