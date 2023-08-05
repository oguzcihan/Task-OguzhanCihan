using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace Business.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            //<kaynak,hedef>
            //<TSource,TDestination>

            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();

        }
    }
}
