using AutoMapper;
using Learning_Management_System.Application.DTOs.AccountDTO;
using Learning_Management_System.Application.Iservices;
using Learning_Management_System.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Learning_Management_System.Application.Services
{
    public class JwtService : IJwtService
    {
        IMapper _mapper;
        UserManager<User> _userManager;
        IConfiguration _config;
        public JwtService(IMapper mapper, UserManager<User> userManager, IConfiguration config)
        {
            _mapper = mapper;
            _userManager = userManager;
            _config = config;
        }
        public async Task<AccountResponseDto> GenerateTokenAsync(User user)
        {
            var userClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim (ClaimTypes.Name, user.FullName)
            };
            var userRole = await _userManager.GetRolesAsync(user);
            foreach (var roleName in userRole)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, roleName));
            }
            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecretKey"]));
            SigningCredentials signingCred = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken MyToken = new JwtSecurityToken
                (

               issuer: _config["JWT:Issuer"],
               audience: _config["JWT:Audience"],
               claims: userClaims,
               signingCredentials: signingCred,
               expires: DateTime.UtcNow.AddMinutes(
               int.Parse(_config["JWT:TokenLifetimeMinutes"]))
                );
            return new AccountResponseDto
            {
                UserId = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Role = user.Role,
                Token = new JwtSecurityTokenHandler().WriteToken(MyToken),
                ExpireAt = MyToken.ValidTo,


            };



        }
    }
}
