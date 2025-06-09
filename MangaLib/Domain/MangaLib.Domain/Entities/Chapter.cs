using Domain.Entities.Base;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Chapter : Entity<int>
    {
        // Конструктор для EF Core
        private Chapter() : base(0) { }

        // Основной конструктор (без параметра id)
        public Chapter(int mangaId, string title, int chapterNumber) : base(0)
        {
            MangaId = mangaId;
            Title = title;
            ChapterNumber = chapterNumber;
            Pages = new List<Page>();
        }

        public int MangaId { get; private set; }
        public string Title { get; private set; }
        public int ChapterNumber { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public ICollection<Page> Pages { get; private set; }
    }
}