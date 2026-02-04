namespace RadiShop.Catalog.Shared.Exceptions.CategoryExceptions;

public sealed class ParentCategoryNotFoundException(Guid id) 
    : CatalogDomainException(CreateMessage(id))
{
    private static string CreateMessage(Guid id) =>
        $"The parent category with id '{id}' was not found.";
}