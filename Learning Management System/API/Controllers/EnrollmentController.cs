using Learning_Management_System.Application.DTOs.CourseDTO;
using Learning_Management_System.Application.DTOs.EnrollmentDTO;
using Learning_Management_System.Application.Iservices;
using Learning_Management_System.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_Management_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        IEnrollmentService _service;

        public EnrollmentController(IEnrollmentService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(EnrollCourseDto dto)
            => Ok(await _service.CreateAsync(dto));

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(UpdateEnrollmentDto dto, long id)
            => Ok(await _service.UpdateAsync(id, dto));

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
            => Ok(await _service.GetByIdAsync(id));

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetByStudentId(long studentId)
            => Ok(await _service.GetBystudentIdAsync(studentId));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()

            => Ok(await _service.GetAllAsync());

    }

}
