using Core.Dtos;

namespace Business.Abstracts
{
    /// <summary>
    /// Department CRUD operasyonlarını içerir
    /// </summary>
    public interface IDepartmentService
    {
        /// <summary>
        /// ID ye göre Department verisini getirme işlemini yapar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DepartmentDto.</returns>
        Task<DepartmentDto> GetByIdAsync(int id);

        /// <summary>
        /// Tüm Departments listesini bulur.
        /// </summary>
        /// <returns>DepartmentDto.</returns>
        Task<IEnumerable<DepartmentDto>> GetAllAsync();

        /// <summary>
        /// Department kaydetme işlemini yapar.
        /// </summary>
        /// <param name="departmentDto"></param>
        /// <returns>DepartmentDto.</returns>
        Task<DepartmentDto> AddAsync(DepartmentDto departmentDto);

        /// <summary>
        /// Department güncelleme işlemini yapar.
        /// </summary>
        /// <param name="depId"></param>
        /// <param name="departmentDto"></param>
        /// <returns>DepartmentDto</returns>
        /// <exception cref="NotFoundException"></exception>
        Task<DepartmentDto> UpdateAsync(int depId, DepartmentDto departmentDto);

        /// <summary>
        /// ID si verilen Department ı silme işlemini yapar.
        /// </summary>
        /// <param name="depId"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        Task RemoveAsync(int depId);
    }
}
