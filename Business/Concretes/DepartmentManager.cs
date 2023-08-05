using AutoMapper;
using Business.Abstracts;
using Business.Exceptions;
using Core.Dtos;
using Core.Entities;
using Core.UnitOfWork;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartmentManager(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public async Task<DepartmentDto> AddAsync(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            await _departmentRepository.AddAsync(department);
            await _unitOfWork.CommitAsync();

            return departmentDto;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var department = await _departmentRepository.GetAll().ToListAsync();
            var departmentDto = _mapper.Map<List<DepartmentDto>>(department);


            return departmentDto;
        }

        public async Task<DepartmentDto> GetByIdAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            var departmentDto = _mapper.Map<DepartmentDto>(department);

            return departmentDto;
        }

        public async Task RemoveAsync(int depId)
        {
            var department = await _departmentRepository.GetByIdAsync(depId);
            if (department == null)
            {
                throw new NotFoundException($"{typeof(Department).Name}({depId}) not found");
            }
            _departmentRepository.Remove(department);

            await _unitOfWork.CommitAsync();
        }

        public async Task<DepartmentDto> UpdateAsync(int depId, DepartmentDto departmentDto)
        {
            var department = await _departmentRepository.GetByIdAsync(depId);
            if (department == null)
            {
                throw new NotFoundException($"{typeof(Department).Name}({depId}) not found");
            }

            var departmentMapping = _mapper.Map(departmentDto, department);

            _departmentRepository.Update(departmentMapping);

            await _unitOfWork.CommitAsync(); //kayıt

            return departmentDto;
        }
    }
}
