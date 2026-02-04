using Microsoft.Extensions.Logging;
using RadiShop.Catalog.Application.Commons.Interfaces;

namespace RadiShop.Catalog.Infrastructure.Persistence
{
    public class UnitOfWork(CatalogDbContext context,
        ILogger<UnitOfWork> logger) : IUnitOfWork
    {
        private readonly CatalogDbContext _context = context;
        private readonly ILogger<UnitOfWork> _logger = logger;

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}

