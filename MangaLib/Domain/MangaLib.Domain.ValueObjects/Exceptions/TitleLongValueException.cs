namespace ValueObjects.Exceptions
{
    internal class TitleLongValueException(string title, int maxLength)
        : ArgumentException($"Title '{title}' exceeds maximum length of {maxLength} characters");
}