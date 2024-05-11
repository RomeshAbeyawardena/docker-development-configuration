namespace HSINet.Identity.Domain.Exceptions;

public class ConfigurationMissingException(string message) 
    : NullReferenceException(message)
{
}
