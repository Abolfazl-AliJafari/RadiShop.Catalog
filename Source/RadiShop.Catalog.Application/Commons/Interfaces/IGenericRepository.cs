using System.Linq.Expressions;
using RadiShop.Catalog.Shared.Types;

namespace RadiShop.Catalog.Application.Commons.Interfaces;

public interface IGenericRepository<TEntity>
{
    void Add(TEntity entity);
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken,params Expression<Func<TEntity, object>>[]? includes);
    Task<IEnumerable<TEntity>?> GetAllAsync(
        CancellationToken cancellationToken,
        Expression<Func<TEntity, bool>>? filter = null,
        bool tracked = true,
        Expression<Func<TEntity, object>>? orderBy = null,
        bool orderByDescending = false,
        params Expression<Func<TEntity, object>>[]? includes);
    Task<IPagedResult<TEntity>?> GetAllAsync(
        CancellationToken cancellationToken,
        int pageNumber,
        int pageSize,
        Expression<Func<TEntity, bool>>? filter = null,
        bool tracked = true,
        Expression<Func<TEntity, object>>? orderBy = null,
        bool orderByDescending = false,
        params Expression<Func<TEntity, object>>[]? includes);
    Task<IPagedResult<TResult>?> GetAllAsync<TResult>(
        CancellationToken cancellationToken,
        Expression<Func<TEntity, TResult>> selector,
        int pageNumber,
        int pageSize,
        Expression<Func<TEntity, bool>>? filter = null,
        bool tracked = true,
        Expression<Func<TEntity, object>>? orderBy = null,
        bool orderByDescending = false,
        params Expression<Func<TEntity, object>>[]? includes);
    void Remove(TEntity entity);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression,CancellationToken cancellationToken);
}