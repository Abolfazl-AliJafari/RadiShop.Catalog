using MediatR;
using RadiShop.Catalog.Shared.Types;

namespace RadiShop.Catalog.Application.Queries.Categories.GetAll;

public sealed record GetAllCategoriesQueryRequest(int PageNumber = 10,
    int PageSize = 10) : IRequest<IPagedResult<GetAllCategoriesQueryResponse>>;