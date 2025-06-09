using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories.Abstractions
{
    /// <summary>
    /// Unit of Work для управления транзакциями и репозиториями
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Репозиторий для работы с мангой
        /// </summary>
        IMangaRepository MangaRepository { get; }

        /// <summary>
        /// Репозиторий для работы с главами
        /// </summary>
        IChapterRepository ChapterRepository { get; }

        /// <summary>
        /// Репозиторий для работы со страницами
        /// </summary>
        IPageRepository PageRepository { get; }

        /// <summary>
        /// Сохраняет все изменения в базу данных
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>True если сохранение прошло успешно</returns>
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Начинает транзакцию
        /// </summary>
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Фиксирует транзакцию
        /// </summary>
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Откатывает транзакцию
        /// </summary>
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}