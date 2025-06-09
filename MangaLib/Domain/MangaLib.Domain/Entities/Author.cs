using Domain.Entities.Base;
using ValueObjects;

namespace Domain.Entities
{
    public class Author : Entity<int>
    {
        // Изменяем конструктор для EF Core
        private Author() : base(0) { } // Конструктор для EF Core

        public Author(AuthorName name) : base(0) // Основной конструктор
        {
            Name = name;
        }

        public AuthorName Name { get; private set; } // Свойство вместо параметра конструктора
    }
}