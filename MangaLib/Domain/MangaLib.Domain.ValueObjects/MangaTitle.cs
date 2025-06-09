using ValueObjects.Base;
using ValueObjects.Validators;

namespace ValueObjects
{
    public sealed class MangaTitle : ValueObject<string>
    {
        public MangaTitle(string value) : base(new TitleValidator(), value) { }
    }
}