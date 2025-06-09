using Application.Models;
using System.Threading.Tasks;

namespace Application.Services.Abstractions
{
    public interface IMangaCatalogService
    {
        Task<MangaModel?> GetMangaByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<MangaModel>> GetAllMangaAsync(CancellationToken cancellationToken);
        Task<IEnumerable<MangaModel>> SearchMangaByTitleAsync(string title, CancellationToken cancellationToken);
        Task<MangaModel> CreateMangaAsync(CreateMangaModel model, CancellationToken cancellationToken);
        Task<bool> UpdateMangaAsync(UpdateMangaModel model, CancellationToken cancellationToken);
        Task<bool> DeleteMangaAsync(int id, CancellationToken cancellationToken);
    }
}