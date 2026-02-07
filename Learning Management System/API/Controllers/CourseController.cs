using Learning_Management_System.Application.DTOs.CourseDTO;
using Learning_Management_System.Application.Iservices;
using Learning_Management_System.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace Learning_Management_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        ICourseService _courseservice;

        public CourseController(ICourseService courseservice)
        {
            _courseservice = courseservice;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateCourseDto courseDto)
            => Ok(await _courseservice.CreateAsync(courseDto));

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateCourseDto courseDto, long id)
            => Ok(await _courseservice.UpdateAsync(id, courseDto));

        [HttpDelete("{id}")]
        [Authorize(Roles  = "Admin")]
        public async Task<IActionResult> Delete( long id)
        {
            await _courseservice.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
            => Ok(await _courseservice.GetByIdAsync(id));
       
        [HttpGet("Name/{Name}")]
        public async Task<IActionResult> GetByName(string Name)
            => Ok(await _courseservice.GetByNameAsync(Name));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()

            => Ok(await _courseservice.GetAllAsync());



    }
}
