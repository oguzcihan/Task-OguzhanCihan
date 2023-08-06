using AutoMapper;
using Business.Abstracts;
using Business.Exceptions;
using Core.Dtos;
using Core.Entities;
using DataAccess.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class CourseManager : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;


        public CourseManager(ICourseRepository courseRepository, IMapper mappper)
        {
            _mapper = mappper;
            _courseRepository = courseRepository;
        }

        public async Task<CourseDto> AddAsync(CourseDto courseDto)
        {
            var course = _mapper.Map<Course>(courseDto);
            await _courseRepository.AddAsync(course);

            return courseDto;
        }

        public async Task<IEnumerable<CourseDto>> GetAllAsync()
        {
            var courses = await _courseRepository.GetAll().ToListAsync();
            var coursesDto = _mapper.Map<List<CourseDto>>(courses);


            return coursesDto;
        }


        public async Task<CourseDto> GetByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            var courseDto = _mapper.Map<CourseDto>(course);

            return courseDto;
        }


        public async Task RemoveAsync(int courseId)
        {
            var course = await _courseRepository.GetByIdAsync(courseId);
            if (course == null)
            {
                throw new NotFoundException($"{typeof(Course).Name}({courseId}) not found");
            }
            await _courseRepository.DeleteAsync(course);

        }


        public async Task<CourseDto> UpdateAsync(int courseId, CourseDto courseDto)
        {
            var course = await _courseRepository.GetByIdAsync(courseId);
            if (course == null)
            {
                throw new NotFoundException($"{typeof(Course).Name}({courseId}) not found");
            }

            var courseMapping = _mapper.Map(courseDto, course);

            _courseRepository.Update(courseMapping);

            return courseDto;
        }
    }
}
