using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace RadiShop.Catalog.Infrastructure.Persistence;

public class CatalogDbContextInitializer(ILogger<CatalogDbContextInitializer>
    logger, CatalogDbContext context)
{
    private readonly ILogger<CatalogDbContextInitializer> _logger = logger;
    private readonly CatalogDbContext _context = context;

    public async Task InitializeAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initializing the database.");
            throw;
        }
    }
}