using MediatR;

namespace RadiShop.Catalog.Application.Commands.Brands.Update;

public record UpdateBrandCommandRequest(Guid BrandId, string Title) : IRequest;