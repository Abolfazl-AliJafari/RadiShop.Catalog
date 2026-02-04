using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RadiShop.Catalog.Infrastructure.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CatalogDbContext>
{
    public CatalogDbContext CreateDbContext(string[] args)
    {
        const string dbConnectionString = "Host=localhost;Port=5432;Database=Catalog_DB;Username=postgres;Password=13851385Ab;";
        var options = new DbContextOptionsBuilder<CatalogDbContext>()
            .UseNpgsql(dbConnectionString)
            .Options;
        return new CatalogDbContext(options);

    }
}