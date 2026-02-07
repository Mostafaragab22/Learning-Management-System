namespace Learning_Management_System.Core.Exceptions;

public class NotFoundException : Exception
{
    public IEnumerable<string> Errors { get; }

    
    public NotFoundException(string message) : base(message)
    {
        Errors = new List<string> { message };
    }
    public NotFoundException(IEnumerable<string> errors)
        : base("Resource not found.")
    {
        Errors = errors;
    }
}
