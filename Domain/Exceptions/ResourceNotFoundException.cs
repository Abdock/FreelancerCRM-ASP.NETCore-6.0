using System.Runtime.Serialization;

namespace Domain.Exceptions;

public class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException()
    {
    }

    protected ResourceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public ResourceNotFoundException(string? message) : base(message)
    {
    }

    public ResourceNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public ResourceNotFoundException(string className, Guid id) : this($"{className} with id {id} not found")
    {
        
    }
}