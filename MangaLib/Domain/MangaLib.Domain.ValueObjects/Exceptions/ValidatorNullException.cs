namespace ValueObjects.Exceptions
{
    internal class ValidatorNullException(string paramName, string message)
        : ArgumentNullException(paramName, message);
}