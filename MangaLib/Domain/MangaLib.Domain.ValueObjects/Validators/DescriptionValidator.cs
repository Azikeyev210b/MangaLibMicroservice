using ValueObjects.Base;
using ValueObjects.Exceptions;

namespace ValueObjects.Validators
{
    public sealed class DescriptionValidator : IValidator<string>
    {
        public void Validate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullOrWhiteSpaceException(
                    nameof(value),
                    ExceptionMessages.DESCRIPTION_NOT_NULL_OR_WHITE_SPACE);
        }
    }
}