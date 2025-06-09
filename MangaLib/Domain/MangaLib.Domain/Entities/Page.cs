using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Page : Entity<int>
    {
        // Конструктор для EF Core
        private Page() : base(0) { }

        public Page(int chapterId, string imageUrl, int pageNumber) : base(0)
        {
            ChapterId = chapterId;
            ImageUrl = imageUrl;
            PageNumber = pageNumber;
        }

        public int ChapterId { get; private set; }
        public string ImageUrl { get; private set; }
        public int PageNumber { get; private set; }
    }
}