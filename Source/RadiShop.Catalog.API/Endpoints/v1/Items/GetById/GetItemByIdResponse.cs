using RadiShop.Catalog.Application.Queries.Items.GetById;

namespace RadiShop.Catalog.API.Endpoints.v1.Items.GetById;

public sealed record GetItemByIdResponse(
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
    public static GetItemByIdResponse FromQuery(GetItemByIdQueryResponse query)
    {
        return new GetItemByIdResponse(
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