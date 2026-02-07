namespace Learning_Management_System.Core.Exceptions;
public class ForbiddenException : Exception
{
    public IEnumerable<string> Errors { get; set; }
    public ForbiddenException(string message) : base(message)
    {
        Errors = new List<string> { message };
    }

    public ForbiddenException(IEnumerable<string> errors)
        : base("Access forbidden for this operation.")
    {
        Errors = errors;
    }
}


