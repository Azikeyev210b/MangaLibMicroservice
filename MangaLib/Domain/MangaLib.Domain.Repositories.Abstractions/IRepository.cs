﻿using Domain.Entities.Base;
using System.Linq.Expressions;

namespace Domain.Repositories.Abstractions
{
    public interface IRepository<TEntity, in TId>
        where TEntity : Entity<TId>
        where TId : struct, IEquatable<TId>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(
            CancellationToken cancellationToken,
            bool asNoTracking = false);

        Task<TEntity?> GetByIdAsync(
            TId id,
            CancellationToken cancellationToken);

        Task<TEntity?> AddAsync(
            TEntity entity,
            CancellationToken cancellationToken);

        Task<bool> UpdateAsync(
            TEntity entity,
            CancellationToken cancellationToken);

        Task<bool> DeleteAsync(
            TEntity entity,
            CancellationToken cancellationToken);

        Task<bool> DeleteAsync(
            TId id,
            CancellationToken cancellationToken);

        Task<bool> ExistsAsync(
            Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken);
    }
}