using FastEndpoints;
using RadiShop.Catalog.Application.Commands.Brands.Remove;

namespace RadiShop.Catalog.API.Endpoints.v1.Brands.Remove;

public sealed record RemoveBrandRequest()
{
    [BindFrom("brandId")] public Guid Id { get; set; }
    public RemoveBrandCommandRequest ToCommand()
    {
        return new RemoveBrandCommandRequest(Id);
    }
}