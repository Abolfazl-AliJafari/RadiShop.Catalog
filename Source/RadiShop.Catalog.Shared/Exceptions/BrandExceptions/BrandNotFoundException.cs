namespace RadiShop.Catalog.Shared.Exceptions.BrandExceptions;

public sealed class BrandNotFoundException(Guid id)
    : CatalogDomainException(CreateMessage(id))
{
    private static string CreateMessage(Guid id) =>
        $"Brand with id '{id}' was not found.";
}