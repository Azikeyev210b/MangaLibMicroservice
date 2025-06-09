using ValueObjects.Base;
using ValueObjects.Validators;

namespace ValueObjects
{
    public sealed class MangaDescription : ValueObject<string>
    {
        public MangaDescription(string value) : base(new DescriptionValidator(), value) { }
    }
}