using FastEndpoints;
using RadiShop.Catalog.Application.Queries.Items.GetById;

namespace RadiShop.Catalog.API.Endpoints.v1.Items.GetById;

public sealed record GetItemByIdRequest
{
    [BindFrom("itemSlug")]
    public string Slug { get; set; }

    public GetItemByIdQueryRequest ToQuery()
    {
        return new GetItemByIdQueryRequest(Slug);
    }
}