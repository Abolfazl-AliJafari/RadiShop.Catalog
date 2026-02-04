using RadiShop.Catalog.Domain.Entities;

namespace RadiShop.Catalog.Application.Queries.Items.GetById;

public sealed record GetItemByIdQueryResponse(
    string Name,
    string Slug,
    string? Description,
    Brand Brand,
    Category Category,
    decimal Price,
    int AvailableStock,
    int MaxStockThreshold)
{
    public static GetItemByIdQueryResponse FromEntity(Item item)
    {
        return new GetItemByIdQueryResponse(
            item.Name,
            item.Slug,
            item.Description,
            item.Brand,
            item.Category,
            item.Price,
            item.AvailableStock,
            item.MaxStockThreshold); 
    }
}