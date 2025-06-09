// MangaLib.Application.Models/Manga/CreateMangaModel.cs
namespace Application.Models
{
    public record CreateMangaModel(
        string Title,
        string Description,
        string CoverImageUrl,
        DateTime ReleaseDate,
        IEnumerable<string> Authors,  // Должно быть именно Authors
        IEnumerable<string> Tags) : ICreateModel;
}