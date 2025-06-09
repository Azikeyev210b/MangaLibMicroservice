using Application.Models;
using System.Threading.Tasks;

namespace Application.Services.Abstractions
{
    public interface IChapterService
    {
        Task<ChapterModel?> GetChapterAsync(int mangaId, int chapterId, CancellationToken cancellationToken);
        Task<IEnumerable<ChapterModel>> GetChaptersForMangaAsync(int mangaId, CancellationToken cancellationToken);
        Task<ChapterModel> UploadChapterAsync(UploadChapterModel model, CancellationToken cancellationToken);
    }
}