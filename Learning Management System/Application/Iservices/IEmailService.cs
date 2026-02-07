namespace Learning_Management_System.Application.Iservices
{
    public interface IEmailService
    {
        Task SendAsync (string to,string subject, string body);
    }
}
