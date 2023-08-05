using Business.Abstracts;
using Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "Admin,Standart")]
    public class DepartmentsController : BaseController
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _departmentService.GetAllAsync();

            return CreateActionResult(RestResponseDto<IEnumerable<DepartmentDto>>.Success(StatusCodes.Status200OK, result));
        }

        [HttpGet("{depId}")]
        public async Task<IActionResult> GetById(int depId)
        {
            var result = await _departmentService.GetByIdAsync(depId);
            return CreateActionResult(RestResponseDto<DepartmentDto>.Success(StatusCodes.Status200OK, result));
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Save([FromBody] DepartmentDto departmentDto)
        {

            if (departmentDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _departmentService.AddAsync(departmentDto);

            return CreateActionResult(RestResponseDto<DepartmentDto>.Success(StatusCodes.Status201Created, result));

        }

        [HttpPut("{depId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int depId, [FromBody] DepartmentDto departmentDto)
        {
            await _departmentService.UpdateAsync(depId, departmentDto);
            return CreateActionResult(RestResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent));
        }

        [HttpDelete("{depId}")]
        public async Task<IActionResult> Delete(int depId)
        {
            await _departmentService.RemoveAsync(depId);

            return CreateActionResult(RestResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent));
        }
    }
}
