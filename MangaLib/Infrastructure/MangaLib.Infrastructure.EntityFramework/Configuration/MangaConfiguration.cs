using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations
{
    public class MangaConfiguration : IEntityTypeConfiguration<Manga>
    {
        public void Configure(EntityTypeBuilder<Manga> builder)
        {
            builder.HasKey(x => x.Id);

            // Конфигурация для хранения авторов (используем приватное поле через Owned Entity)
            builder.Property<string>("_authors")
                .HasColumnName("Authors")
                .IsRequired()
                .HasMaxLength(500); // Формат: "Автор1|Автор2"

            // Конфигурация для хранения тегов (используем приватное поле через Owned Entity)
            builder.Property<string>("_tags")
                .HasColumnName("Tags")
                .IsRequired()
                .HasMaxLength(500); // Формат: "Жанр1|Жанр2"

            // Конфигурация остальных свойств
            builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.CoverImageUrl).IsRequired();
            builder.Property(x => x.ReleaseDate).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}