using RadiShop.Catalog.Domain.Entities;

namespace RadiShop.Catalog.Application.Queries.Items.GetAll;

public sealed record GetAllItemsQueryResponse(
    string Name,
    string Slug,
    string? Description,
    decimal Price,
    Brand Brand,
    Category Category,
    int AvailableStock,
    int MaxStockThreshold)
{
    public static GetAllItemsQueryResponse FromEntity(Item item)
    {
        return new GetAllItemsQueryResponse(
            item.Name,
            item.Slug,
            item.Description,
            item.Price,
            item.Brand,
            item.Category,
            item.AvailableStock,
            item.MaxStockThreshold); 
    }
}