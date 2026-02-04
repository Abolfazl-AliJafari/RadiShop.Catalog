using MediatR;

namespace RadiShop.Catalog.Application.Commands.Categories.Update;

public record UpdateCategoryCommandRequest(Guid CategoryId, string Title) : IRequest;