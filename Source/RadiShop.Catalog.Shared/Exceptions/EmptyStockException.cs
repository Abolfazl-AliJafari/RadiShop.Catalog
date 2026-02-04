namespace RadiShop.Catalog.Shared.Exceptions;

public sealed class EmptyStockException(string name) : CatalogDomainException(CreateMessage(name))
{
    private static string CreateMessage(string name) =>
        $"Empty stock, product item {name} is sold out";
}