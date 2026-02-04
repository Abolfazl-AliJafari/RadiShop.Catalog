using MediatR;

namespace RadiShop.Catalog.Application.Commands.Brands.Remove;

public sealed record RemoveBrandCommandRequest(Guid BrandId) : IRequest;