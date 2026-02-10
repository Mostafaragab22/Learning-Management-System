using AutoMapper;
using Learning_Management_System.Application.DTOs.AccountDTO;
using Learning_Management_System.Application.Iservices;
using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Learning_Management_System.API.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Learning_Management_System.Application.Services
{
    public class AccountService:IAccountService
    {
        IMapper _mapper;
        IEmailService _emailService;
        IUserService _userService;
        
        UserManager<User> _userManager;
        SignInManager<User> _signInManager;
        IJwtService _jwtService;
        public AccountService (IMapper mapper, IUserService userService ,UserManager<User> userManager,
            SignInManager<User> signInManager, IJwtService jwtService, IEmailService emailService)
        {
            _mapper = mapper;
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
            _emailService = emailService;
        }
        public async Task<AccountResponseDto> CreateAccountAsync(RegisterDto registerDto)
        {
            var user = _mapper.Map<User>(registerDto);
            var result = await _userManager.CreateAsync(user,registerDto.Password);
            if (!result.Succeeded)
                throw new BadRequestException(result.Errors.Select(e => e.Description));
            await _userManager.AddToRoleAsync(user,Role.Student);
           
            return await _jwtService.GenerateTokenAsync(user);
                  
        }

        public async Task<AccountResponseDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                throw new UnauthorizedException("Invalid email or password");
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!signInResult.Succeeded)
                throw new UnauthorizedException("Invalid email or password");
            return await _jwtService.GenerateTokenAsync(user);
           
        }

        public async Task ForgotPasswordAsync(ForgotPasswordDto dto)
        {
            var user =await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                return;
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetlink=$"http://Frontend/reset-password? email={dto.Email}&token ={Uri.EscapeDataString(token)}";

           await _emailService.SendAsync(dto.Email, "Reset Password",
               $"Reset your password using this link : {resetlink}");
            
        }

        public async Task ResetPasswordAsync(ResetPasswordDto dto)
        {
            if (dto.NewPassword != dto.ConfirmPassword)
                throw new BadRequestException("Password not match");

            var user = await _userManager.FindByEmailAsync(dto.Email)??
                throw new NotFoundException("User not found");
            var result = await _userManager.ResetPasswordAsync
                (
                user,
                dto.Token,
                dto.NewPassword 
                );

            if (!result.Succeeded)
                throw new BadRequestException(result.Errors.Select(e => e.Description));

        }

        public async Task ChangePasswordAsync(ChangePasswordDto dto,long userId)
        {

            if (dto.NewPassword != dto.ConfirmPassword)
                throw new BadRequestException("Passwords do not match");

            var user = await _userManager.FindByIdAsync(userId.ToString())
                ?? throw new UnauthorizedException("User not found");

            var result = await _userManager.ChangePasswordAsync(
                user,
                dto.CurrentPassword,
                dto.NewPassword
            );

            if (!result.Succeeded)
                throw new BadRequestException(result.Errors.Select(e => e.Description));
        }
    }

}
