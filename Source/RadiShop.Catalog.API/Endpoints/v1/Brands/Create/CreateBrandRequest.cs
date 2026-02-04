using RadiShop.Catalog.Application.Commands.Brands.Create;

namespace RadiShop.Catalog.API.Endpoints.v1.Brands.Create;

public sealed record CreateBrandRequest(string Title)
{
    public CreateBrandCommandRequest ToCommand()
    {
        return new CreateBrandCommandRequest(Title);
    }
}