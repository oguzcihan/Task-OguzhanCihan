using Core.Dtos;

namespace Business.Abstracts
{
    /// <summary>
    /// Course CRUD operasyonlarını içerir.
    /// </summary>
    public interface ICourseService
    {
        /// <summary>
        /// Id si verilen Course u listeler.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>CourseDto</returns>
        Task<CourseDto> GetByIdAsync(int id);

        /// <summary>
        /// Tüm kursları listeler.
        /// </summary>
        /// <returns>CourseDto</returns>
        Task<IEnumerable<CourseDto>> GetAllAsync();

        /// <summary>
        /// Course kaydetme işlemini yapar.
        /// </summary>
        /// <param name="courseDto"></param>
        /// <returns>CourseDto</returns>
        Task<CourseDto> AddAsync(CourseDto studentDto);

        /// <summary>
        /// Id ile bulunan ilgili Course u güncelleme işlemini yapar.
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="courseDto"></param>
        /// <returns>CourseDto</returns>
        /// <exception cref="NotFoundException"></exception>
        Task<CourseDto> UpdateAsync(int courseId, CourseDto studentDto);

        /// <summary>
        /// ID si verilen Course u siler.
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        Task RemoveAsync(int courseId);
    }
}
