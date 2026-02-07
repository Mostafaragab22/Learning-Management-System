using Learning_Management_System.Application.DTOs.CategoryDTO;
using Learning_Management_System.Application.DTOs.UserDTO;
using Learning_Management_System.Application.Iservices;
using Learning_Management_System.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Learning_Management_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut("Profile/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateUserProfileDto dto, long id)
            => Ok(await _userService.UpdateAsync(id, dto));

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Updatee(long id, AdminUserDto dto)
            => Ok(await _userService.UpdateAdmiAsync(id, dto));

        [HttpGet("ById/{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
           => Ok(await _userService.GetUserById(id));

        [HttpGet("ByName/{Name}")]
        public async Task<IActionResult> GetByNameAsync(string Name)
            => Ok(await _userService.GetUserByName(Name));
    }
}
