using Core.Dtos;
using Core.Entities;
using System.Linq.Expressions;

namespace Business.Abstracts
{
    /// <summary>
    /// Student CRUD operasyonlarını içerir.
    /// </summary>
    public interface IStudentService
    {

        Task<RestResponseDto<List<StudentWithDepartmentDto>>> GetStudentsWithDepartment();
        Task<StudentDto> GetByIdAsync(int id);
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDto> AddAsync(int courseId, StudentDto studentDto);
        Task<StudentDto> UpdateAsync(int courseId, int studentId, StudentDto studentDto);
        Task RemoveAsync(int id);

    }
}
