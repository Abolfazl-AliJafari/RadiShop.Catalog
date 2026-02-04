using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RadiShop.Catalog.Domain.Entities;
using Npgsql.EntityFrameworkCore.PostgreSQL.ValueGeneration;

namespace RadiShop.Catalog.Infrastructure.Persistence;

public class CatalogDbContext(DbContextOptions<CatalogDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    private const string DefaultSchema = "catalog";
    
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(DefaultSchema);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var property = entityType.FindProperty("Id");
            if (property != null && property.ClrType == typeof(Guid))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property("Id")
                    .HasValueGenerator<NpgsqlSequentialGuidValueGenerator>();
            }
        }
    }
}