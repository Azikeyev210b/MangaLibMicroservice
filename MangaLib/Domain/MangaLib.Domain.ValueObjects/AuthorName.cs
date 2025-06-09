// MangaLib.Domain/ValueObjects/AuthorName.cs
namespace ValueObjects
{
    public class AuthorName
    {
        public string Value { get; } // Единственное свойство

        public AuthorName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Author name cannot be empty");

            Value = value;
        }
    }
}