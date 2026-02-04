using FastEndpoints;
using RadiShop.Catalog.Application.Commands.Categories.Remove;

namespace RadiShop.Catalog.API.Endpoints.v1.Categories.Remove;

public sealed record RemoveCategoryRequest()
{
    [BindFrom("categoryId")] public Guid Id { get; set; }
    public RemoveCategoryCommandRequest ToCommand()
    {
        return new RemoveCategoryCommandRequest(Id);
    }
}