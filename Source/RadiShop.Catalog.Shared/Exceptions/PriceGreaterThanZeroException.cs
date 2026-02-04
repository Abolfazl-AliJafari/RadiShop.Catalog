namespace RadiShop.Catalog.Shared.Exceptions;

public sealed class PriceGreaterThanZeroException() : CatalogDomainException(CreateMessage())
{
    private static string CreateMessage() =>
        "Item price desired should be greater than zero";
}
