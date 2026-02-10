namespace Learning_Management_System.Application.DTOs.AccountDTO
{
    public class AccountResponseDto
    {
        public long UserId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
        public List<string> Role {  get; set; } = new List<string>();

        public DateTime ExpireAt { get; set; } 
    }
}
