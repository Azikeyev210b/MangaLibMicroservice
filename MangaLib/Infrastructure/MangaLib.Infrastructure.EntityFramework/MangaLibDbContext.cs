using Domain.Entities;
using Infrastructure.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework
{
    public class MangaLibDbContext : DbContext
    {
        public DbSet<Manga> Manga { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Author> Authors { get; set; }

        public MangaLibDbContext(DbContextOptions<MangaLibDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Применяем все конфигурации из текущей сборки
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MangaLibDbContext).Assembly);

            // Дополнительные настройки моделей
            ConfigureModelRelationships(modelBuilder);
        }

        private static void ConfigureModelRelationships(ModelBuilder modelBuilder)
        {
            // Настройка удаления связанных записей
            modelBuilder.Entity<Manga>()
                .HasMany(m => m.Chapters)
                .WithOne()
                .HasForeignKey(c => c.MangaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Chapter>()
                .HasMany(c => c.Pages)
                .WithOne()
                .HasForeignKey(p => p.ChapterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}