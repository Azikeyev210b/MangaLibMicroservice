namespace Application.Models
{
    public record CreateChapterModel(
        int MangaId,
        string Title,
        IEnumerable<UploadPageModel> Pages) : ICreateModel;
}