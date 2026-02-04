using RadiShop.Catalog.Shared.Exceptions;
using RadiShop.Catalog.Shared.Extensions;

namespace RadiShop.Catalog.Domain.Entities;

public class Item
{
    public string Name { get; private init; } = null!;
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public int AvailableStock { get; private set; }
    public string Slug { get; private set; } = null!;
    public int MaxStockThreshold { get; private set; }
    public Brand Brand { get; private set; } = null!;
    public Guid BrandId { get; private set; }
    public Category Category { get; private set; } = null!;
    public Guid CategoryId { get; private set; }
    public static Item Create(string name, string description, int maxStockThreshold, Guid brandId, Guid categoryId, decimal price = default)
    {
        var newItem = new Item
        {
            Name = name,
            BrandId = brandId,
            CategoryId = categoryId,
            Description = description,
            Slug = name.ToKebabCase(),
            Price = price
        };

        newItem.SetMaxStockThreshold(maxStockThreshold);

        return newItem;
    }
    public void Update(string description, Guid brandId, Guid categoryId)
    {
        BrandId = brandId;
        CategoryId = categoryId;
        Description = description;
    }
    public void SetMaxStockThreshold(int maxStockThreshold)
    {
        if (maxStockThreshold <= 0)
            throw new PriceGreaterThanZeroException();

        MaxStockThreshold = maxStockThreshold;
    }
    public int RemoveStock(int quantity)
    {
        if (AvailableStock == 0)
        {
            throw new EmptyStockException(Name);
        }

        if (quantity <= 0)
        {
            throw new QuantityGreaterThanZeroException();
        }

        var removed = Math.Min(quantity, AvailableStock);

        AvailableStock -= removed;
        return removed;
    }
    public int AddStock(int quantity)
    {
        var original = AvailableStock;

        if ((AvailableStock + quantity) > MaxStockThreshold)
        {
            AvailableStock += (MaxStockThreshold - AvailableStock);
        }
        else
        {
            AvailableStock += quantity;
        }

        return AvailableStock - original;
    }

    public void UpdatePrice(decimal price)
    {
        if (price <= 0)
            throw new PriceGreaterThanZeroException();

        Price = price;
    }
}