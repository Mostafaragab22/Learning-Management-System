using Learning_Management_System.Application.DTOs.UserDTO;

namespace Learning_Management_System.Application.Iservices
{
    public interface IUserService
    {
        Task<UserResponseDto> GetUserById(long id);
        Task<UserResponseDto> GetUserByName(string Name);
        Task<UserResponseDto> UpdateAsync(long userId, UpdateUserProfileDto dto);
        Task<UserResponseDto> UpdateAdmiAsync(long id,AdminUserDto dto);

    }
}
