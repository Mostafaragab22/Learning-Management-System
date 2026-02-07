using Learning_Management_System.Core.Enums;

namespace Learning_Management_System.Application.DTOs.AccountDTO
{
    public class AccountResponseDto
    {
        public long UserId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public EnumRole Role { get; set; } = EnumRole.Student;

        public string Token { get; set; }

        public DateTime ExpireAt { get; set; } 
    }
}
