namespace Learning_Management_System.Core.Exceptions
{
    public class BadRequestException:Exception
    {
        public IEnumerable<string> Errors { get; set; }
        public BadRequestException(string message) : base(message)
        { 
            Errors = new List<string> { message };

        }
        public BadRequestException(IEnumerable<string> errors) : base("one or more validatio errors occurred")
        {
           
            Errors = errors;
        }


    }
}
