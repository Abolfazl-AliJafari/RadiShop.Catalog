namespace RadiShop.Catalog.Shared.Exceptions.CategoryExceptions;

public sealed class CategoryAlreadyExistsException(string title)
    : CatalogDomainException(CreateMessage(title))
{
    private static string CreateMessage(string title) =>
        $"Category with Title '{title}' already exists.";
}