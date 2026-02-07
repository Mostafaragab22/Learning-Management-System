using Learning_Management_System.Application.DTOs.EnrollmentDTO;
using Learning_Management_System.Application.DTOs.LessonDTO;
using Learning_Management_System.Application.Iservices;
using Learning_Management_System.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_Management_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        ILessonService _service;

        public LessonController(ILessonService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize (Roles = "Admin")]
        public async Task<IActionResult> Create(AddLessonDto dto)
            => Ok(await _service.CreateAsync(dto));

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateLessonDto dto, long id)
           => Ok(await _service.UpdateAsync(id, dto));

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
           => Ok(await _service.GetByIdAsync(id));

        [HttpGet("{Name}")]
        public async Task<IActionResult> GetByName(string Name)
         => Ok(await _service.GetByNameAsync(Name));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()

            => Ok(await _service.GetAllAsync());

    }

}
