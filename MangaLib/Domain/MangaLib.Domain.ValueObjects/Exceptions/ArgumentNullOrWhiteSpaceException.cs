namespace ValueObjects.Exceptions
{
    internal class ArgumentNullOrWhiteSpaceException(string paramName, string message)
        : ArgumentException(message, paramName);
}