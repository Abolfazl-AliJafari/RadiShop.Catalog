using RadiShop.Catalog.Infrastructure.Persistence;

namespace RadiShop.Catalog.API.Extensions;

public static class InitializerExtensions
{
    public static async Task InitializeDatabaseAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var initializer = scope.ServiceProvider.GetRequiredService<CatalogDbContextInitializer>();
        await initializer.InitializeAsync();
    }
}