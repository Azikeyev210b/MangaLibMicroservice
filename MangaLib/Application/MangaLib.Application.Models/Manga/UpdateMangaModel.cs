namespace Application.Models
{
    public record UpdateMangaModel(
        int Id,
        string? Title = null,
        string? Description = null,
        string? CoverImageUrl = null) : IModel<int>;
}