using Learning_Management_System.Application.DTOs.AccountDTO;
using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Application.Iservices
{
    public interface IJwtService
    {
        Task<AccountResponseDto> GenerateTokenAsync(User user);
    }
}
