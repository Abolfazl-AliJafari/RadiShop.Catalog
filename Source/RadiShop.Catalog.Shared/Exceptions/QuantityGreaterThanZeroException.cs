namespace RadiShop.Catalog.Shared.Exceptions;

public sealed class QuantityGreaterThanZeroException() : CatalogDomainException(CreateMessage())
{
    private static string CreateMessage() =>
        "Item units desired should be greater than zero";
}