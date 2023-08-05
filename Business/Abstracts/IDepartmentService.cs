using Core.Dtos;

namespace Business.Abstracts
{
    /// <summary>
    /// Department CRUD operasyonlarını içerir
    /// </summary>
    public interface IDepartmentService
    {
        Task<DepartmentDto> GetByIdAsync(int id);
        Task<IEnumerable<DepartmentDto>> GetAllAsync();
        Task<DepartmentDto> AddAsync(DepartmentDto departmentDto);
        Task<DepartmentDto> UpdateAsync(int depId, DepartmentDto departmentDto);
        Task RemoveAsync(int depId);
    }
}
