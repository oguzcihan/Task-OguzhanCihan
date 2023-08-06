using Core.Dtos;
using Core.Dtos.Responses;
using Core.Entities;
using System.Linq.Expressions;

namespace Business.Abstracts
{
    /// <summary>
    /// Student CRUD operasyonlarını içerir.
    /// </summary>
    public interface IStudentService
    {
        StudentResponse GetById(int id);
        IEnumerable<StudentResponse> GetAll();
        Task<StudentDto> AddAsync(StudentDto studentDto);
        Task<StudentDto> UpdateAsync( int studentId, StudentDto studentDto);
        Task RemoveAsync(int id);

    }
}
