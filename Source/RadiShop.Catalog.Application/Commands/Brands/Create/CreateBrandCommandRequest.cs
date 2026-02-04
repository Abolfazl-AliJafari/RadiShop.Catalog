using MediatR;

namespace RadiShop.Catalog.Application.Commands.Brands.Create;

public record CreateBrandCommandRequest(string Title) : IRequest<CreateBrandCommandResponse>;