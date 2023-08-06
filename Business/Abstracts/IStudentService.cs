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
        /// <summary>
        /// ID si verilen Student verisini getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StudentDto</returns>
        /// <exception cref="NotFoundException"></exception>
        StudentResponse GetById(int id);

        /// <summary>
        /// Tüm student listesini döner.
        /// </summary>
        /// <returns>StudentResponse</returns>
        /// <exception cref="NotFoundException"></exception>
        IEnumerable<StudentResponse> GetAll();

        /// <summary>
        /// Student ekleme işlemi yapar.
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns>StudentDto</returns>
        /// <exception cref="NotFoundException"></exception>
        Task<StudentDto> AddAsync(StudentDto studentDto);

        /// <summary>
        /// Student güncelleme işlemini yapar.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="studentDto"></param>
        /// <returns>StudentDto</returns>
        /// <exception cref="NotFoundException"></exception>
        Task<StudentDto> UpdateAsync( int studentId, StudentDto studentDto);

        /// <summary>
        /// ID si verilen ilgili Student ı siler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        Task RemoveAsync(int id);

    }
}
