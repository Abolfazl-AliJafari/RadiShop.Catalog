using RadiShop.Catalog.Application.Commands.Brands.Create;

namespace RadiShop.Catalog.API.Endpoints.v1.Brands.Create;

public sealed record CreateBrandResponse(Guid Id)
{
    public static CreateBrandResponse FromCommand(CreateBrandCommandResponse command)
    {
        return new CreateBrandResponse(command.Id);
    }
}