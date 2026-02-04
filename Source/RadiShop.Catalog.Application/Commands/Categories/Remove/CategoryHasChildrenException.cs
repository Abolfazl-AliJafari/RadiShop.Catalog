using RadiShop.Catalog.Shared.Exceptions;

namespace RadiShop.Catalog.Application.Commands.Categories.Remove;

public sealed class CategoryHasChildrenException(Guid id) : CatalogDomainException(CreateMessage(id))
{
    private static string CreateMessage(Guid id) =>
        $"The category with id '{id}' cannot be deleted because it has child categories.";
}