using FastEndpoints;
using RadiShop.Catalog.Application.Queries.Brands.GetById;

namespace RadiShop.Catalog.API.Endpoints.v1.Brands.GetById;

public sealed record GetBrandByIdRequest
{
    [BindFrom("brandId")]
    public Guid Id { get; set; }

    public GetBrandByIdQueryRequest ToQuery()
    {
        return new GetBrandByIdQueryRequest(Id);
    }
}