using Learning_Management_System.Core.Enums;

namespace Learning_Management_System.Application.DTOs.UserDTO
{
    public class UserResponseDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phoene {  get; set; }
        public decimal Age { get; set; }
        public EnumRole Role { get; set; }

    }
}
