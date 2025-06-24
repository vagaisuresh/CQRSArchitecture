/* 
    Option 1: Create Your Own NotFoundException Class
    If you're following Clean Architecture or a similar pattern, it’s common to define custom exceptions like this:
    File: Application/Exceptions/NotFoundException.cs
*/

namespace CQRS.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message)
        : base(message)
    {
    }
}