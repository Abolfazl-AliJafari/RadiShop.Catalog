using RadiShop.Catalog.Application.Commands.Categories.Create;

namespace RadiShop.Catalog.API.Endpoints.v1.Categories.Create;

public sealed record CreateCategoryResponse(Guid Id)
{
    public static CreateCategoryResponse FromCommand(CreateCategoryCommandResponse command)
    {
        return new CreateCategoryResponse(command.Id);
    }
}