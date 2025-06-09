using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Repositories.Abstractions
{
    public interface IChapterRepository
    {
        Task<Chapter?> GetByIdAsync(int mangaId, int chapterId, CancellationToken ct);
        Task<IEnumerable<Chapter>> GetForMangaAsync(int mangaId, CancellationToken ct);
        Task AddAsync(Chapter chapter, CancellationToken ct);
        Task<bool> SaveChangesAsync(CancellationToken ct);
    }
}