namespace RadiShop.Catalog.Shared.Exceptions.ItemExceptions;

public sealed class ItemAlreadyExistsException(string name)
    : CatalogDomainException(CreateMessage(name))
{
    private static string CreateMessage(string name) =>
        $"Item with Name '{name}' already exists.";
}