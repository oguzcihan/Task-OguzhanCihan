using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class StudentWithDepartmentDto : StudentDto
    {
        public CourseDto department { get; set; }
    }
}
