namespace Learning_Management_System.Application.DTOs.AccountDTO
{
    public class RegisterDto
    {
       
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }  
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}
