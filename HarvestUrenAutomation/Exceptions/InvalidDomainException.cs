using System.Runtime.Serialization;

namespace HarvestUrenAutomation.Exceptions;

[Serializable]
public class InvalidDomainException : Exception  
{
    public InvalidDomainException()
    {
    }

    public InvalidDomainException(string message) : base(message)
    {
    }
    
    
    public InvalidDomainException(string message, Exception inner)
        : base(message, inner)
    {
    }
    
    // Without this constructor, deserialization will fail
    protected InvalidDomainException(SerializationInfo info, StreamingContext context) 
        : base(info, context)
    {
    }
    
}
