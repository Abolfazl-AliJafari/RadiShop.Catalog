using MediatR;

namespace RadiShop.Catalog.Application.Queries.Items.GetById;

public sealed record GetItemByIdQueryRequest(string Slug) : IRequest<GetItemByIdQueryResponse>;