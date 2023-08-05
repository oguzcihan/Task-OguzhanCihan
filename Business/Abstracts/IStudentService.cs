using Core.Dtos;
using Core.Entities;

namespace Business.Abstracts
{
    public interface IStudentService : IBaseService<StudentDto>
    {
   
        List<Student> GetListByDepartment(int categoryId);

        Task<StudentDto> AddAsync(int courseId, StudentDto studentRequest);
        Task<StudentDto> UpdateAsync(int courseId, StudentDto studentRequest);
        Task DeleteAsync(StudentDto studentDto);

    }
}
