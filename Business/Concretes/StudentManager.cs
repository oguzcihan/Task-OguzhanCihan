using AutoMapper;
using Business.Abstracts;
using Business.Exceptions;
using Core.Dtos;
using Core.Entities;
using Core.Entities.Relationships;
using DataAccess.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class StudentManager : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentCourseRepository _studentCourseRepository;


        private readonly IMapper _mapper;

        public StudentManager(IStudentRepository studentRepository, ICourseRepository courseRepository, IStudentCourseRepository studentCourseRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _studentCourseRepository = studentCourseRepository;

            _mapper = mapper;
        }

        /// <summary>
        /// ID si verilen Student verisini getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StudentDto</returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                throw new NotFoundException($"{typeof(Student).Name}({id}) not found");
            }
            var studentDto = _mapper.Map<StudentDto>(student);

            return studentDto;
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var students = await _studentRepository.GetAll().ToListAsync();
            var studentDto = _mapper.Map<List<StudentDto>>(students);

            return studentDto;
        }

        /// <summary>
        /// Student ekleme işlemi yapar.
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="studentDto"></param>
        /// <returns>StudentDto</returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<StudentDto> AddAsync(int courseId, StudentDto studentDto)
        {
            var course = await _courseRepository.GetByIdAsync(courseId);
            if (course == null)
            {
                throw new NotFoundException($"{typeof(Course).Name}({courseId}) not found");
            }
            var studentMapping = _mapper.Map<Student>(studentDto);

            var studentCourse = new StudentCourse()
            {
                Course = course,
                Student = studentMapping
            };

            await _studentCourseRepository.AddAsync(studentCourse);
            await _studentRepository.AddAsync(studentMapping);


            return studentDto;
        }

        /// <summary>
        /// Student güncelleme işlemini yapar.
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="studentId"></param>
        /// <param name="studentDto"></param>
        /// <returns>StudentDto</returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<StudentDto> UpdateAsync(int courseId, int studentId, StudentDto studentDto)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);
            var course = await _courseRepository.GetByIdAsync(courseId);
            if (course == null)
            {
                throw new NotFoundException($"{typeof(Course).Name}({courseId}) not found");
            }
            else if (student == null)
            {
                throw new NotFoundException($"{typeof(Course).Name}({studentId}) not found");
            }

            var studentMapping = _mapper.Map(studentDto, student);

            _studentRepository.Update(studentMapping);


            return studentDto;
        }

        /// <summary>
        /// ID si verilen ilgili Student ı siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task RemoveAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null)
            {
                throw new NotFoundException($"{typeof(Student).Name}({id}) not found");
            }
            await _studentRepository.DeleteAsync(student);

        }

        public Task<RestResponseDto<List<StudentWithDepartmentDto>>> GetStudentsWithDepartment()
        {
            throw new NotImplementedException();
        }


    }
}
