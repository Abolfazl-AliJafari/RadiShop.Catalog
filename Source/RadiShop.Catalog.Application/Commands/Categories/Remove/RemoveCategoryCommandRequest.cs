using MediatR;

namespace RadiShop.Catalog.Application.Commands.Categories.Remove;

public sealed record RemoveCategoryCommandRequest(Guid CategoryId) : IRequest;