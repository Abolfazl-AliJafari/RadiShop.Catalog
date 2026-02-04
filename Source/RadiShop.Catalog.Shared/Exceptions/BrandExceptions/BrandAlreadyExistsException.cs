namespace RadiShop.Catalog.Shared.Exceptions.BrandExceptions;

public sealed class BrandAlreadyExistsException(string title)
    : CatalogDomainException(CreateMessage(title))
{
    private static string CreateMessage(string title) =>
        $"Brand with Title '{title}' already exists.";
}