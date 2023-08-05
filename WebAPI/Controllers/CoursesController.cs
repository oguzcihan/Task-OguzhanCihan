using Business.Abstracts;
using Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "Admin,Standart")]
    public class CoursesController : BaseController
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _courseService.GetAllAsync();

            return CreateActionResult(RestResponseDto<IEnumerable<CourseDto>>.Success(StatusCodes.Status200OK, result));
        }

        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetById(int courseId)
        {
            var result = await _courseService.GetByIdAsync(courseId);
            return CreateActionResult(RestResponseDto<CourseDto>.Success(StatusCodes.Status200OK, result));
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Save([FromBody] CourseDto courseDto)
        {

            if (courseDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _courseService.AddAsync(courseDto);

            return CreateActionResult(RestResponseDto<CourseDto>.Success(StatusCodes.Status201Created, result));

        }

        [HttpPut("{courseId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int courseId, [FromBody] CourseDto courseDto)
        {
            await _courseService.UpdateAsync(courseId, courseDto);
            return CreateActionResult(RestResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent));
        }

        [HttpDelete("{courseId}")]
        public async Task<IActionResult> Delete(int courseId)
        {
            await _courseService.RemoveAsync(courseId);

            return CreateActionResult(RestResponseDto<NoContentDto>.Success(StatusCodes.Status204NoContent));
        }
    }
}
