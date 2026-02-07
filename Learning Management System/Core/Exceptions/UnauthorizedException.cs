namespace Learning_Management_System.Core.Exceptions
{
    public class UnauthorizedException:Exception
    {
        public IEnumerable<string> Errors { get; set; }
        public UnauthorizedException(string message) : base(message)
        {
            Errors = new List<string> { message };

        }

        public UnauthorizedException(IEnumerable<string> errors) : base("Unauthorized Access ")
        {
            Errors = errors;
        }

    }
}
