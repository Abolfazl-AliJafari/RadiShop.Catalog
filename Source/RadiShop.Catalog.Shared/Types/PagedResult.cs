namespace RadiShop.Catalog.Shared.Types;

public class PagedResult<T> : IPagedResult<T>
{
    public IReadOnlyCollection<T> Items { get; private init; } = Array.Empty<T>();
    public int PageNumber { get; private init; }
    public int PageSize { get; private init; }
    public int ItemsCount { get; private init; }

    public int TotalPages => (int)Math.Ceiling(ItemsCount / (double)PageSize);
    public bool HasNextPage => PageNumber < TotalPages;
    public bool HasPreviousPage => PageNumber > 1;

    public static PagedResult<T> Create(IEnumerable<T> items, int pageNumber, int pageSize, int itemsCount)
    {
        return new PagedResult<T>
        {
            Items = items.ToList().AsReadOnly(),
            PageNumber = pageNumber,
            PageSize = pageSize,
            ItemsCount = itemsCount
        };
    }   
}