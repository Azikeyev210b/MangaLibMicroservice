namespace ValueObjects.Exceptions
{
    internal class TitleShortValueException(string title, int minLength)
        : ArgumentException($"Title '{title}' is shorter than minimum length of {minLength} characters");
}