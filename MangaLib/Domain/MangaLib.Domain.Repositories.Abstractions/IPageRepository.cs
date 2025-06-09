using Domain.Entities;

namespace Domain.Repositories.Abstractions
{
    public interface IPageRepository : IRepository<Page, int>
    {
        // Специфичные методы для страниц
        Task<IEnumerable<Page>> GetPagesForChapterAsync(
            int chapterId,
            CancellationToken cancellationToken,
            bool asNoTracking = false);

        Task<Page?> GetByNumberAsync(
            int chapterId,
            int pageNumber,
            CancellationToken cancellationToken);

        Task<int> GetPageCountAsync(
            int chapterId,
            CancellationToken cancellationToken);
    }
}