using MediatR;
using RadiShop.Catalog.Application.Queries.Categories.GetAll;
using RadiShop.Catalog.Shared.Types;

namespace RadiShop.Catalog.Application.Queries.Brands.GetAll;

public sealed record GetAllBrandsQueryRequest(int PageNumber = 10, int PageSize = 10) : IRequest<IPagedResult<GetAllBrandsQueryResponse>>;