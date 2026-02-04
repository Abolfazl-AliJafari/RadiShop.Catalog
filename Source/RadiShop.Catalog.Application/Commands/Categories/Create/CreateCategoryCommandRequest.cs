using MediatR;

namespace RadiShop.Catalog.Application.Commands.Categories.Create;

public record CreateCategoryCommandRequest(string Title,Guid? ParentId = null) : IRequest<CreateCategoryCommandResponse>;