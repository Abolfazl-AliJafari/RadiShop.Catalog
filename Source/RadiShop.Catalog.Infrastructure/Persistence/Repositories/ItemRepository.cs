using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Domain.Entities;

namespace RadiShop.Catalog.Infrastructure.Persistence.Repositories;

public class ItemRepository(CatalogDbContext dbContext) : GenericRepository<Item>(dbContext), IItemRepository
{
    public async Task<Item?> GetByIdAsync(string slug, CancellationToken cancellationToken, params Expression<Func<Item, object>>[]? includes)
    {
        IQueryable<Item> query = _dbSet;

        if (includes is { Length: > 0 })
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));

            return await query.FirstOrDefaultAsync(e => EF.Property<string>(e, "Slug") == slug, cancellationToken);
        }

        return await _dbSet.FindAsync([slug], cancellationToken);
    }
}