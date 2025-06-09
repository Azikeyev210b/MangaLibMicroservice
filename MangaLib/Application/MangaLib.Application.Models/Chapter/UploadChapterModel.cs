// MangaLib.Application.Models/Chapter/UploadChapterModel.cs

namespace Application.Models
{
    public record UploadChapterModel(
        int MangaId,
        string Title,
        int ChapterNumber,
        IEnumerable<UploadPageModel> Pages) : ICreateModel;
}