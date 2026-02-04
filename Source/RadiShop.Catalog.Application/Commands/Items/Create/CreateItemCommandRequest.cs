using MediatR;
using RadiShop.Catalog.Application.Commands.Categories.Create;

namespace RadiShop.Catalog.Application.Commands.Items.Create;

public record CreateItemCommandRequest(
    string Name,
    string Description,
    Guid CategoryId,
    Guid BrandId,
    int MaxStockThreshold) : IRequest<CreateItemCommandResponse>;