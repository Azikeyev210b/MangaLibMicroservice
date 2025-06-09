namespace Application.Models
{
    public record MangaModel(
        int Id,
        string Title,
        string Description,
        string CoverImageUrl,
        DateTime ReleaseDate,
        IEnumerable<string> Authors,
        IEnumerable<string> Tags) : IModel<int>;
}