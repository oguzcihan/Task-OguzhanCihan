using Business.Abstracts;
using Core.Dtos;
using Core.Dtos.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    public class StudentsController : BaseController
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _studentService.GetAll();

            return CreateActionResult(RestResponseDto<IEnumerable<StudentResponse>>.Success(StatusCodes.Status200OK, result));
        }

        [Authorize(Roles = "Admin,Standart")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _studentService.GetById(id);
            return CreateActionResult(RestResponseDto<StudentResponse>.Success(StatusCodes.Status200OK, result));
        }

        [Authorize(Roles = "Admin,Standart")]
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Save([FromBody] StudentDto studentDto)
        {

            if (studentDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _studentService.AddAsync(studentDto);

            return CreateActionResult(RestResponseDto<StudentDto>.Success(StatusCodes.Status201Created, result));

        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] StudentDto studentDto)
        {
            await _studentService.UpdateAsync(id, studentDto);
            return CreateActionResult(RestResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _studentService.RemoveAsync(id);

            return CreateActionResult(RestResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent));
        }

    }
}
