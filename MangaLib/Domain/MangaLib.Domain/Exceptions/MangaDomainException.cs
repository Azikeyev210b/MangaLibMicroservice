namespace Domain.Exceptions
{
    public class MangaDomainException : Exception
    {
        public MangaDomainException() { }
        public MangaDomainException(string message) : base(message) { }
        public MangaDomainException(string message, Exception inner) : base(message, inner) { }
    }
}