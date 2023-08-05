using AutoMapper;
using Business.Abstracts;
using Business.Exceptions;
using Core.Dtos;
using Core.Entities;
using DataAccess.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentManager(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }


        /// <summary>
        /// Department kaydetme işlemini yapar.
        /// </summary>
        /// <param name="departmentDto"></param>
        /// <returns>DepartmentDto.</returns>
        public async Task<DepartmentDto> AddAsync(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            var result = await _departmentRepository.AddAsync(department);
            if (result == null)
            {
                throw new Exception("AddAsync()");
            }


            return departmentDto;
        }

        /// <summary>
        /// Tüm Departments listesini bulur.
        /// </summary>
        /// <returns>DepartmentDto.</returns>
        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var department = await _departmentRepository.GetAll().ToListAsync();
            var departmentDto = _mapper.Map<List<DepartmentDto>>(department);


            return departmentDto;
        }

        /// <summary>
        /// ID ye göre Department verisini getirme işlemini yapar.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>DepartmentDto.</returns>
        public async Task<DepartmentDto> GetByIdAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            var departmentDto = _mapper.Map<DepartmentDto>(department);

            return departmentDto;
        }

        /// <summary>
        /// ID si verilen Department ı silme işlemini yapar.
        /// </summary>
        /// <param name="depId"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task RemoveAsync(int depId)
        {
            var department = await _departmentRepository.GetByIdAsync(depId);
            if (department == null)
            {
                throw new NotFoundException($"{typeof(Department).Name}({depId}) not found");
            }
            await _departmentRepository.DeleteAsync(department);

        }

        /// <summary>
        /// Department güncelleme işlemini yapar.
        /// </summary>
        /// <param name="depId"></param>
        /// <param name="departmentDto"></param>
        /// <returns>DepartmentDto</returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<DepartmentDto> UpdateAsync(int depId, DepartmentDto departmentDto)
        {
            var department = await _departmentRepository.GetByIdAsync(depId);
            if (department == null)
            {
                throw new NotFoundException($"{typeof(Department).Name}({depId}) not found");
            }

            var departmentMapping = _mapper.Map(departmentDto, department);

            _departmentRepository.Update(departmentMapping);

            return departmentDto;
        }
    }
}
