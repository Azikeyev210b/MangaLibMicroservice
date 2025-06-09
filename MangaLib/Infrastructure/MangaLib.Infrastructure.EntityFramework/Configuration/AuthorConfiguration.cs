using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValueObjects;

namespace Infrastructure.EntityFramework.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);

            // Конфигурация для ValueObject AuthorName
            builder.Property(a => a.Name)
                .HasConversion(
                    n => n.Value,
                    s => new AuthorName(s))
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}