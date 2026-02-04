using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiShop.Catalog.Domain.Entities;

namespace RadiShop.Catalog.Infrastructure.Persistence.Configurations;

public sealed class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Items");

        builder.HasKey(x => x.Slug);
        
        builder.HasIndex(x => x.Name)
            .IsUnique();
        
        builder.Property(x => x.Slug)
            .HasMaxLength(200);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(5000);
         
        builder.Property(x => x.Price)
            .HasColumnType("decimal(15,2)");
    }
}