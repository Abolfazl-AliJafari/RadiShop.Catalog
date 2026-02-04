using MediatR;
using RadiShop.Catalog.Shared.Types;

namespace RadiShop.Catalog.Application.Queries.Items.GetAll;

public sealed record GetAllItemsQueryRequest(int PageNumber = 10,
    int PageSize = 10) : IRequest<IPagedResult<GetAllItemsQueryResponse>>;