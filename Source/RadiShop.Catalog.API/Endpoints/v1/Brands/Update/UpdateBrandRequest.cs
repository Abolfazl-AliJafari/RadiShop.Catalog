using RadiShop.Catalog.Application.Commands.Brands.Update;

namespace RadiShop.Catalog.API.Endpoints.v1.Brands.Update;

public sealed record UpdateBrandRequest(Guid Id,string Title)
{
    public UpdateBrandCommandRequest ToCommand()
    {
        return new UpdateBrandCommandRequest(Id,Title);
    }
}