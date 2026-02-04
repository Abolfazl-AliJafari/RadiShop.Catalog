using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiShop.Catalog.Domain.Entities;

namespace RadiShop.Catalog.Infrastructure.Persistence.Configurations;

public class BrandConfiguration: IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Title)
            .IsUnique();
        builder.Property(x => x.Title)
            .HasMaxLength(100)
            .IsRequired(true);
    }
}