using Business.Abstracts;
using Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StudentsController : BaseController
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _studentService.GetAllAsync();

            return CreateActionResult(RestResponseDto<IEnumerable<StudentDto>>.Success(StatusCodes.Status200OK, result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _studentService.GetByIdAsync(id);
            return CreateActionResult(RestResponseDto<StudentDto>.Success(StatusCodes.Status200OK, result));
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Save([FromQuery] int courseId, [FromBody] StudentDto studentDto)
        {

            if (studentDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _studentService.AddAsync(courseId, studentDto);

            return CreateActionResult(RestResponseDto<StudentDto>.Success(StatusCodes.Status201Created, result));

        }

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromQuery] int courseId, [FromBody] StudentDto studentDto)
        {
            await _studentService.UpdateAsync(courseId, id, studentDto);
            return CreateActionResult(RestResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.RemoveAsync(id);

            return CreateActionResult(RestResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent));
        }

    }
}
