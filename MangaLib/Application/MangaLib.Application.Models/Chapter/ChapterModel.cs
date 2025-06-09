namespace Application.Models
{
    public record ChapterModel(
        int Id,
        string Title,
        int PageCount,
        DateTime UploadDate) : IModel<int>;
}