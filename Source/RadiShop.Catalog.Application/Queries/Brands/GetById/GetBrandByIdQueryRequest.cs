using MediatR;
using RadiShop.Catalog.Application.Queries.Categories.GetById;

namespace RadiShop.Catalog.Application.Queries.Brands.GetById;

public sealed record GetBrandByIdQueryRequest(Guid CategoryId) : IRequest<GetBrandByIdQueryResponse>;