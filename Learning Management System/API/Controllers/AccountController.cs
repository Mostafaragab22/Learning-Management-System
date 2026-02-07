using Learning_Management_System.Application.DTOs.AccountDTO;
using Learning_Management_System.Application.DTOs.CategoryDTO;
using Learning_Management_System.Application.Iservices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Learning_Management_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [EnableRateLimiting("Global")]
    public class AccountController : ControllerBase
    {
        IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Create(RegisterDto dto)

           => Ok(await _accountService.CreateAccountAsync(dto));
        [HttpPost("login")]
        public async Task<IActionResult> login(LoginDto dto)

           => Ok(await _accountService.LoginAsync(dto));

        [HttpPost("changePassword")]
        public async Task<IActionResult> changePassword(ChangePasswordDto dto, long userId)

        {
            await _accountService.ChangePasswordAsync(dto,userId);
            return NoContent();
        }

        [HttpPost("ResetPassword")]

        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)

        {
            await _accountService.ResetPasswordAsync(dto);
            return NoContent();
        }
        [HttpPost("ForgotPassword")]

        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto dto)

        {
            await _accountService.ForgotPasswordAsync(dto);
            return NoContent();
        }

        [Authorize(Policy = "AdminOnly")]

        [HttpGet("test")]
        public IActionResult Test() => Ok("Admin works");

        [Authorize]
        [HttpGet("claims")]
        public IActionResult Claims()
        {
            return Ok(User.Claims.Select(c => new
            {
                c.Type,
                c.Value
            }));
        }

    }
}
