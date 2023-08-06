using AutoMapper;
using Business.Abstracts;
using Business.Exceptions;
using Core.Dtos;
using Core.Dtos.Responses;
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
        private readonly IDepartmentRepository _departmentRepository;


        private readonly IMapper _mapper;

        public StudentManager(IStudentRepository studentRepository, ICourseRepository courseRepository, IStudentCourseRepository studentCourseRepository, IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _studentCourseRepository = studentCourseRepository;

            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        /// <summary>
        /// ID si verilen Student verisini getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StudentDto</returns>
        /// <exception cref="NotFoundException"></exception>
        public StudentResponse GetById(int id)
        {

            var studentResponse = _studentRepository.GetStudentWithCourses(id);
            if (studentResponse == null)
            {
                throw new NotFoundException($"{typeof(Student).Name}({id}) not found");
            }

            return studentResponse;

        }

        public IEnumerable<StudentResponse> GetAll()
        {
            var studentResponse = _studentRepository.GetStudentsWithCourses();
            if (studentResponse == null)
            {
                throw new NotFoundException($"There are no entries in the list!");
            }

            return studentResponse;
        }

        /// <summary>
        /// Student ekleme işlemi yapar.
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="studentDto"></param>
        /// <returns>StudentDto</returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<StudentDto> AddAsync(StudentDto studentDto)
        {
            if (studentDto.CourseIds == null || !studentDto.CourseIds.Any())
            {
                throw new ClientSideException("En az bir ders seçmelisiniz.");
            }

            var department = await _departmentRepository.GetByIdAsync(studentDto.DepartmentId);
            if (department == null)
            {
                throw new NotFoundException($"{typeof(Department).Name}({studentDto.DepartmentId}) not found");
            }
            var studentMapping = _mapper.Map<Student>(studentDto);
            await _studentRepository.AddAsync(studentMapping);

            foreach (var courseId in studentDto.CourseIds)
            {
                var course = await _courseRepository.GetByIdAsync(courseId);
                if (course == null)
                {
                    throw new NotFoundException($"{typeof(Course).Name}({courseId}) not found");
                }

                var studentCourse = new StudentCourse()
                {
                    Course = course,
                    Student = studentMapping
                };

                await _studentCourseRepository.AddAsync(studentCourse);
            }


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
        public async Task<StudentDto> UpdateAsync(int studentId, StudentDto studentDto)
        {

            var existingStudent = await _studentRepository.GetByIdAsync(studentId);
            if (existingStudent == null)
            {
                throw new NotFoundException($"{typeof(Student).Name}({studentId}) not found");
            }

            var department = await _departmentRepository.GetByIdAsync(studentDto.DepartmentId);
            if (department == null)
            {
                throw new NotFoundException($"{typeof(Department).Name}({studentDto.DepartmentId}) not found");
            }

            var student = _mapper.Map(studentDto, existingStudent);
            student.Department = department;
            _studentRepository.Update(student);


            var existingCourseIds = _studentCourseRepository.GetList(sc => sc.StudentId == studentId)
                .Select(sc => sc.CourseId);

            var studentCoursesDifference = existingCourseIds.Except(studentDto.CourseIds);
            foreach (var courseIdToDelete in studentCoursesDifference)
            {
                // Öğrenci ile ilişkilendirilmiş olan dersi bul
                var studentCourseToDelete = _studentCourseRepository
                    .GetList(sc => sc.StudentId == studentId && sc.CourseId == courseIdToDelete);

                if (studentCourseToDelete != null)
                {
                    // İlişkiyi sil
                    _studentCourseRepository.RemoveRange(studentCourseToDelete);
                }
            }
            foreach (var newCourseId in studentDto.CourseIds)
            {
                if (!existingCourseIds.Contains(newCourseId))
                {
                    var course = await _courseRepository.GetByIdAsync(newCourseId);
                    if (course == null)
                    {
                        throw new NotFoundException($"{typeof(Course).Name}({newCourseId}) not found");
                    }

                    var studentCourse = new StudentCourse
                    {
                        Course = course,
                        Student = student
                    };

                    _studentCourseRepository.Add(studentCourse);
                }

            }
           

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


    }
}
