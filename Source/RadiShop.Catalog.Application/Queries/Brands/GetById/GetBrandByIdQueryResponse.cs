using RadiShop.Catalog.Application.Queries.Categories.GetById;
using RadiShop.Catalog.Domain.Entities;

namespace RadiShop.Catalog.Application.Queries.Brands.GetById;

public sealed record GetBrandByIdQueryResponse(
    Guid Id,
    string Title)
{
    public static GetBrandByIdQueryResponse FromEntity(Brand brand)
    {
        return new GetBrandByIdQueryResponse(
            brand.Id,
            brand.Title); 
    }
}