using Business.Abstracts;
using Core.Dtos;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filters;

namespace WebAPI.Controllers
{

    public class StudentsController : BaseController
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _studentService.GetAll();

            return CreateActionResult(RestResponseDto<List<StudentDto>>.Success(StatusCodes.Status200OK, result));
        }

        [ServiceFilter(typeof(NotFoundFilter<Student>))]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _studentService.GetById(id);
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

        [HttpPut]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update([FromQuery] int courseId, [FromBody] StudentDto studentDto)
        {
            await _studentService.UpdateAsync(courseId, studentDto);
            return CreateActionResult(RestResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var studentDto = _studentService.GetById(id);
            await _studentService.DeleteAsync(studentDto);

            return CreateActionResult(RestResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent));
        }

    }
}
