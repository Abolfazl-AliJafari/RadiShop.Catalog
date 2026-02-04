namespace RadiShop.Catalog.Shared.Types;

public interface IPagedResult<out T>
{
    IReadOnlyCollection<T> Items { get; }
    int PageNumber { get;  }
    int PageSize { get; } 
    int ItemsCount { get; }
    bool HasNextPage { get; }
    bool HasPreviousPage { get; }
    int TotalPages { get; }
}