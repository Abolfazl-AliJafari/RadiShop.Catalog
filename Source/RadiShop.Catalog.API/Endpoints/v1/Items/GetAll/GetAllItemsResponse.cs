using RadiShop.Catalog.API.Endpoints.v1.Items.GetAll;
using RadiShop.Catalog.Application.Queries.Items.GetAll;

namespace RadiShop.Catalog.API.Endpoints.v1.Items.GetAll;

public sealed record GetAllItemsResponse(
    string Name,
    string Slug,
    string? Description,
    Guid BrandId,
    string BrandName,
    Guid CategoryId,
    string CategoryName,
    decimal Price,
    int AvailableStock,
    int MaxStockThreshold)
{
    public static GetAllItemsResponse FromQuery(GetAllItemsQueryResponse query)
    {
        return new GetAllItemsResponse(
            query.Name,
            query.Slug,
            query.Description,
            query.Brand.Id,
            query.Brand.Title,
            query.Category.Id,
            query.Category.Title,
            query.Price,
            query.AvailableStock,
            query.MaxStockThreshold);
    }
}