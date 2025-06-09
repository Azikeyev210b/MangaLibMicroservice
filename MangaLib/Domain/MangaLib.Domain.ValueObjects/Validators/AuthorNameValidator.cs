using ValueObjects.Base;
using ValueObjects.Exceptions;

namespace ValueObjects.Validators
{
    public sealed class AuthorNameValidator : IValidator<string>
    {
        public const int MIN_LENGTH = 2;
        public const int MAX_LENGTH = 50;

        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(
                    nameof(value),
                    ExceptionMessages.AUTHOR_NAME_INVALID);

            if (value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
                throw new AuthorNameLengthException(value, MIN_LENGTH, MAX_LENGTH);
        }
    }
}