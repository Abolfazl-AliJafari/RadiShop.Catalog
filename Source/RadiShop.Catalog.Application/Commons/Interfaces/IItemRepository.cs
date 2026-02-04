using System.Linq.Expressions;
using RadiShop.Catalog.Domain.Entities;

namespace RadiShop.Catalog.Application.Commons.Interfaces;

public interface IItemRepository : IGenericRepository<Item>
{
    [Obsolete("Use GetByIdAsync(string slug) instead", true)]
    new Task<Item?> GetByIdAsync(Guid id, CancellationToken cancellationToken, params Expression<Func<Item, object>>[]? includes);
    
    Task<Item?> GetByIdAsync(string slug, CancellationToken cancellationToken, params Expression<Func<Item, object>>[]? includes);
}