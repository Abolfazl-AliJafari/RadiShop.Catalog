using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RadiShop.Catalog.Domain.Entities;

namespace RadiShop.Catalog.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Title)
            .IsUnique();
        builder.Ignore(x => x.Path);

        builder.Property(x => x.Title)
            .HasMaxLength(100)
            .IsRequired(true);

        builder.Property(x => x.ParentId)
            .IsRequired(false);

        builder.HasMany(x => x.Childrens)
            .WithOne(z => z.Parent)
            .HasForeignKey(x => x.ParentId);
    }
}