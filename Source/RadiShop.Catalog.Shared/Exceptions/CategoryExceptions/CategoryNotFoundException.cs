namespace RadiShop.Catalog.Shared.Exceptions.CategoryExceptions;

public sealed class CategoryNotFoundException(Guid id)
    : CatalogDomainException(CreateMessage(id))
{
    private static string CreateMessage(Guid id) =>
        $"Category with id '{id}' was not found.";
}