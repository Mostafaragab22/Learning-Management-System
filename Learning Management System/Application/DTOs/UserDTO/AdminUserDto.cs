using Learning_Management_System.Core.Enums;

namespace Learning_Management_System.Application.DTOs.UserDTO
{
    public class AdminUserDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public EnumRole UserRole { get; set; }
    }
}
