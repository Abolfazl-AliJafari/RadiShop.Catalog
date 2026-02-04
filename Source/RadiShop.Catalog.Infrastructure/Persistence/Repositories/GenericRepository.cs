using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Shared.Extensions;
using RadiShop.Catalog.Shared.Types;

namespace RadiShop.Catalog.Infrastructure.Persistence.Repositories

{ 
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        #region Fields
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly CatalogDbContext _dbContext;
        #endregion

        #region Ctors
        public GenericRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        #endregion

        #region Methods
        public void Add(TEntity entity)
        { 
            _dbSet.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
        {
            return _dbSet.AnyAsync(expression, cancellationToken);
        }

        public async Task<TEntity?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken,
            params Expression<Func<TEntity, object>>[]? includes)
        {
            IQueryable<TEntity> query = _dbSet;

            if (includes is { Length: > 0 })
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));

                return await query.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id, cancellationToken);
            }

            return await _dbSet.FindAsync([id], cancellationToken);
        }
        public async Task<IEnumerable<TEntity>?> GetAllAsync(
            CancellationToken cancellationToken,
            Expression<Func<TEntity, bool>>? filter = null,
            bool tracked = true,
            Expression<Func<TEntity, object>>? orderBy = null,
            bool orderByDescending = false,
            params Expression<Func<TEntity, object>>[]? includes)
        {
            cancellationToken.ThrowIfCancellationRequested();
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy is not null)
            {
                query = orderByDescending? 
                    query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();

            }
            if (includes != null && includes.Length != 0)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return await query.ToListAsync(cancellationToken: cancellationToken);
        }
        public async Task<IPagedResult<TEntity>?> GetAllAsync(
            CancellationToken cancellationToken,
            int pageNumber,
            int pageSize,
            Expression<Func<TEntity, bool>>? filter = null,
            bool tracked = true,
            Expression<Func<TEntity, object>>? orderBy = null,
            bool orderByDescending = false,
            params Expression<Func<TEntity, object>>[]? includes)
        {
            cancellationToken.ThrowIfCancellationRequested();
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy is not null)
            {
                query = orderByDescending? 
                    query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();

            }
            if (includes != null && includes.Length != 0)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return await query.ToPagedResultAsync(pageNumber,pageSize,cancellationToken: cancellationToken);
        }
        public async Task<IPagedResult<TResult>?> GetAllAsync<TResult>(
            CancellationToken cancellationToken,
            Expression<Func<TEntity, TResult>> selector,
            int pageNumber,
            int pageSize,
            Expression<Func<TEntity, bool>>? filter = null,
            bool tracked = true,
            Expression<Func<TEntity, object>>? orderBy = null,
            bool orderByDescending = false,
            params Expression<Func<TEntity, object>>[]? includes)
        {
            cancellationToken.ThrowIfCancellationRequested();
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy is not null)
            {
                query = orderByDescending? 
                    query.OrderByDescending(orderBy) : query.OrderBy(orderBy);
            }
            if (!tracked)
            {
                query = query.AsNoTracking();

            }
            if (includes != null && includes.Length != 0)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            var resultQuery = query.Select(selector);

            return await resultQuery.ToPagedResultAsync(pageNumber,pageSize,cancellationToken: cancellationToken);
        }
        #endregion
    }

}