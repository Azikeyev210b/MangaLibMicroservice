using Domain.Entities.Base;
using Common.Enums;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Manga : Entity<int>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string CoverImageUrl { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public MangaStatus Status { get; private set; }

        // Навигационное свойство для глав (единственное необходимое изменение)
        public ICollection<Chapter> Chapters { get; } = new List<Chapter>();

        // Приватные поля для хранения данных
        private string _authors;
        private string _tags;

        // Публичные методы доступа
        public string GetAuthors() => _authors;
        public string GetTags() => _tags;
        public MangaStatus GetCurrentStatus() => Status;

        public Manga(
            int id,
            string title,
            string description,
            string coverImageUrl,
            DateTime releaseDate)
            : base(id)
        {
            Title = title;
            Description = description;
            CoverImageUrl = coverImageUrl;
            ReleaseDate = releaseDate;
            Status = MangaStatus.Ongoing;
            _authors = string.Empty;
            _tags = string.Empty;
        }

        // Методы изменения состояния
        public void SetAuthors(IEnumerable<string> authors)
            => _authors = string.Join("|", authors);

        public void SetTags(IEnumerable<string> tags)
            => _tags = string.Join("|", tags);

        public void UpdateBasicInfo(string title, string description, string coverImageUrl)
        {
            Title = title;
            Description = description;
            CoverImageUrl = coverImageUrl;
        }

        public void MarkAsCompleted() => Status = MangaStatus.Completed;
    }
}