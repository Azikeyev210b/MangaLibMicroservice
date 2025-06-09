namespace ValueObjects.Exceptions
{
    internal static class ExceptionMessages
    {
        public const string TITLE_NOT_NULL_OR_WHITE_SPACE = "Title must not be null or whitespace";
        public const string DESCRIPTION_NOT_NULL_OR_WHITE_SPACE = "Description must not be null or whitespace";
        public const string AUTHOR_NAME_INVALID = "Author name must be between 2-50 characters";
        public const string VALIDATOR_MUST_BE_SPECIFIED = "Validator must be specified for the type";
    }
}