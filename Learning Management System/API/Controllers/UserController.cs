using Learning_Management_System.Application.DTOs.UserDTO;
using Learning_Management_System.Application.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

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

        [HttpPut("Profile")]

        public async Task<IActionResult> Update(UpdateUserProfileDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized();
            await _userService.UpdateAsync(long.Parse(userId), dto);
            return NoContent();
        }

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
