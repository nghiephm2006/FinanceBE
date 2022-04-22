using Finance.Business.Request.Students;
using Finance.Business.Students.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finance.WebAPI.Controllers
{
    public partial class StudentsController : ControllerBase
    {
        /// <summary>
        /// Get List Students
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/students")]
        [SwaggerOperation(Tags = new[] { "Students" })]
        public async Task<IActionResult> GetStudents([FromQuery] SearchStudentRequest request)
        {
            var students = await _studentService.GetAllStudents(request);
            return Ok(students);
        }

        /// <summary>
        /// Get Student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/v1/students/{id}")]
        [SwaggerOperation(Tags = new[] { "Students" })]
        public async Task<IActionResult> GetStudent([FromRoute] Guid id)
        {
            var student = await _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound("NOT_FOUND_MESSAGE");
            }

            return Ok(student);
        }

        /// <summary>
        /// Tạo mới 1 student
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/v1/students")]
        [SwaggerOperation(Tags = new[] { "Students" })]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentRequest request)
        {
            var student = await _studentService.CreateStudent(request, _configuration);
            if (student == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "INTERNAL_SERVER_ERROR");
            }

            return Created(nameof(CreateStudent), student);
        }

        /// <summary>
        /// Cập nhập 1 student
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("~/api/v1/students/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Students" })]
        public async Task<IActionResult> UpdateStudent([FromRoute] Guid id, UpdateStudentRequest request)
        {
            var student = await _studentService.UpdateStudent(id, request);
            if (student == null)
            {
                return NotFound("Message");
            }

            return Ok(student);
        }

        /// <summary>
        /// Xóa 1 student qua id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("~/api/v1/students/{id:Guid}")]
        [SwaggerOperation(Tags = new[] { "Students" })]
        public async Task<IActionResult> DeleteStudent([FromRoute] Guid id)
        {
            var resultInt = await _studentService.DeleteStudent(id);
            if (resultInt != 1)
            {
                return BadRequest("BAD_REQUEST");
            }

            return NoContent();
        }
    }
}
