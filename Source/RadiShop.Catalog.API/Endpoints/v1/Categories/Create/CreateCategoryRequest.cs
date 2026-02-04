using RadiShop.Catalog.Application.Commands.Categories.Create;

namespace RadiShop.Catalog.API.Endpoints.v1.Categories.Create;

public sealed record CreateCategoryRequest(string Title, Guid? ParentId = null)
{
    public CreateCategoryCommandRequest ToCommand()
    {
        return new CreateCategoryCommandRequest(Title, ParentId);
    }
}