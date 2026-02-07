using Learning_Management_System.Application.DTOs.AccountDTO;
using Learning_Management_System.Application.DTOs.QuestionsDTO;
using Learning_Management_System.Application.DTOs.UserDTO;

namespace Learning_Management_System.Application.Iservices
{
    public interface IAccountService
    {
        Task<AccountResponseDto> CreateAccountAsync(RegisterDto registerDto);
        Task<AccountResponseDto> LoginAsync( LoginDto loginDto);
        Task ForgotPasswordAsync(ForgotPasswordDto dto);
        Task ResetPasswordAsync(ResetPasswordDto dto);
        Task ChangePasswordAsync(ChangePasswordDto dto,long userId);
     
       
    }
}
