using RadiShop.Catalog.Application.Commands.Categories.Update;

namespace RadiShop.Catalog.API.Endpoints.v1.Categories.Update;

public sealed record UpdateCategoryRequest(Guid Id,string Title)
{
    public UpdateCategoryCommandRequest ToCommand()
    {
        return new UpdateCategoryCommandRequest(Id,Title);
    }
}