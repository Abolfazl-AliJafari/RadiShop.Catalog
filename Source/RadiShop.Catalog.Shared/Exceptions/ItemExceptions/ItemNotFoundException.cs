namespace RadiShop.Catalog.Shared.Exceptions.ItemExceptions;

public sealed class ItemNotFoundException(string slug)
    : CatalogDomainException(CreateMessage(slug))
{
    private static string CreateMessage(string slug) =>
        $"Item with slug '{slug}' was not found.";
}