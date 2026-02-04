using FastEndpoints;
using RadiShop.Catalog.Application.Queries.Categories.GetById;

namespace RadiShop.Catalog.API.Endpoints.v1.Categories.GetById;

public sealed record GetCategoryByIdRequest
{
    [BindFrom("categoryId")]
    public Guid Id { get; set; }

    public GetCategoryByIdQueryRequest ToQuery()
    {
        return new GetCategoryByIdQueryRequest(Id);
    }
}