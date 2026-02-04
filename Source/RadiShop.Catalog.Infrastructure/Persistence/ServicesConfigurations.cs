using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Infrastructure.Persistence.Repositories;
using RadiShop.Catalog.Shared;

namespace RadiShop.Catalog.Infrastructure.Persistence;

public static class ServicesConfigurations
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
    {
        var appSettings = configuration.GetSection(AppSettings.ConfigurationSectionName).Get<AppSettings>();

        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IBrandRepository, BrandRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<CatalogDbContextInitializer>();
        
        var connectionString = appSettings!.ConnectionStrings.PostgreSQL;
        services.AddDbContext<CatalogDbContext>(options =>
        {
            options.UseNpgsql(connectionString,
                builder => builder.MigrationsAssembly(typeof(CatalogDbContext).Assembly.FullName));
        });
        
        return services;
    }
}