using Core.Dtos;

namespace Business.Abstracts
{
    /// <summary>
    /// Course CRUD operasyonlarını içerir.
    /// </summary>
    public interface ICourseService
    {
        Task<CourseDto> GetByIdAsync(int id);
        Task<IEnumerable<CourseDto>> GetAllAsync();
        Task<CourseDto> AddAsync(CourseDto studentDto);
        Task<CourseDto> UpdateAsync(int courseId, CourseDto studentDto);
        Task RemoveAsync(int courseId);
    }
}
