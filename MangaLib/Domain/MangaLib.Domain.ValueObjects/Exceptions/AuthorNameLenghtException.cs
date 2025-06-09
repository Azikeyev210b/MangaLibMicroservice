namespace ValueObjects.Exceptions
{
    internal class AuthorNameLengthException(string name, int min, int max)
        : ArgumentException($"Author name '{name}' must be between {min}-{max} characters");
}