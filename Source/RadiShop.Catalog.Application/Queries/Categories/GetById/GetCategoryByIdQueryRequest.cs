using MediatR;

namespace RadiShop.Catalog.Application.Queries.Categories.GetById;

public sealed record GetCategoryByIdQueryRequest(Guid CategoryId) : IRequest<GetCategoryByIdQueryResponse>;