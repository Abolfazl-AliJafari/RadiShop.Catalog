using RadiShop.Catalog.Application.Queries.Items.GetAll;

namespace RadiShop.Catalog.API.Endpoints.v1.Items.GetAll;

public sealed record GetAllItemsRequest(
    int PageNumber,
    int PageSize)
{
    public GetAllItemsQueryRequest ToQuery()
    {
        return new GetAllItemsQueryRequest(PageNumber, PageSize);
    }
}