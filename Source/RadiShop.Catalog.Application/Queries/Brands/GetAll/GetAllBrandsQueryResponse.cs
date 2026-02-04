using RadiShop.Catalog.Domain.Entities;

namespace RadiShop.Catalog.Application.Queries.Brands.GetAll;

public sealed record GetAllBrandsQueryResponse(
    Guid Id,
    string Title)
{
    public static GetAllBrandsQueryResponse FromEntity(Brand brand)
    {
        return new GetAllBrandsQueryResponse(
            brand.Id,
            brand.Title); 
    }
}