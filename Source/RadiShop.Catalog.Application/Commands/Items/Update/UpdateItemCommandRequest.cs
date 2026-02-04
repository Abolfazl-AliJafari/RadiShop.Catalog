using MediatR;

namespace RadiShop.Catalog.Application.Commands.Items.Update;

public record UpdateItemCommandRequest(string Slug,
    string Description,
    Guid BrandId,
    Guid CategoryId) : IRequest;