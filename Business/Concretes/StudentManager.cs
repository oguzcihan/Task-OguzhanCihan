using AutoMapper;
using Business.Abstracts;
using Business.Exceptions;
using Core.Dtos;
using Core.Entities;
using Core.Entities.Relationships;
using DataAccess.Abstracts;
using DataAccess.Context;
using System;
using System.Linq.Expressions;

namespace Business.Concretes
{
    public class StudentManager : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly AppDbContext _appDbContext;

        private readonly IMapper _mappper;

        public StudentManager(IStudentRepository studentRepository, ICourseRepository courseRepository, AppDbContext appDbContext, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _appDbContext = appDbContext;
            _mappper = mapper;
        }

        public List<StudentDto> GetAll()
        {
            var students = _studentRepository.GetList().ToList();
            var studentDto = _mappper.Map<List<StudentDto>>(students);

            return studentDto;
        }

        public StudentDto GetById(int studentId)
        {
            var student = _studentRepository.Get(b => b.Id == studentId);
            var studentDto = _mappper.Map<StudentDto>(student);

            return studentDto;
        }


        public List<Student> GetListByDepartment(int departmentId)
        {
            return new List<Student>(_studentRepository.GetList(b => b.Department.Id == departmentId).ToList());
        }


        public async Task<StudentDto> AddAsync(int courseId, StudentDto studentDto)
        {

            var course = _courseRepository.Get(c => c.Id == courseId);
            var studentMapping = _mappper.Map<Student>(studentDto);

            var studentCourse = new StudentCourse()
            {
                Course = course,
                Student = studentMapping
            };

            _appDbContext.Add(studentCourse);


            var student = await _studentRepository.AddAsync(studentMapping);
            var _studentDto = _mappper.Map<StudentDto>(student);

            return _studentDto;
        }

        public async Task DeleteAsync(StudentDto studentDto)
        {
            var student = _mappper.Map<Student>(studentDto);
            await _studentRepository.DeleteAsync(student);
        }


        public async Task<StudentDto> UpdateAsync(int courseId, StudentDto studentDto)
        {
            var course = _courseRepository.Get(c => c.Id == courseId);

            if (course != null)
            {
                var studentMapping = _mappper.Map<Student>(studentDto);

                var student = await _studentRepository.UpdateAsync(studentMapping);
                var _studentDto = _mappper.Map<StudentDto>(student);

                return _studentDto;
            }

            throw new NotFoundException("Course not found");
        }

        public Task<StudentDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<StudentDto> Where(Expression<Func<StudentDto, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AnyAsync(Expression<Func<StudentDto, bool>> expression)
        {
            return await _studentRepository.AnyAsync(expression);
        }

        public Task<IEnumerable<StudentDto>> AddRangeAsync(IEnumerable<StudentDto> entities)
        {
            throw new NotImplementedException();
        }

        public Task<StudentDto> AddAsync(StudentDto entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(StudentDto entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(StudentDto entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<StudentDto> entities)
        {
            throw new NotImplementedException();
        }
    }
}
