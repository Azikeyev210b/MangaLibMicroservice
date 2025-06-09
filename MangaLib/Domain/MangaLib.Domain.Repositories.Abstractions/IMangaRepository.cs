using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Repositories.Abstractions
{
    public interface IMangaRepository
    {
        Task<Manga?> GetByIdAsync(int id, CancellationToken ct);
        Task<IEnumerable<Manga>> GetAllAsync(CancellationToken ct);
        Task<IEnumerable<Manga>> FindByTitleAsync(string title, CancellationToken ct);
        Task AddAsync(Manga manga, CancellationToken ct);
        Task UpdateAsync(Manga manga, CancellationToken ct);
        Task DeleteAsync(Manga manga, CancellationToken ct);
        Task<bool> SaveChangesAsync(CancellationToken ct);
    }
}