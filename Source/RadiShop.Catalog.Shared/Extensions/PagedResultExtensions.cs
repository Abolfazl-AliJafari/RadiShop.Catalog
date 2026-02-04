using Microsoft.EntityFrameworkCore;
using RadiShop.Catalog.Shared.Types;

namespace RadiShop.Catalog.Shared.Extensions;

public static class PagedResultExtensions
{
    public static async Task<IPagedResult<T>> ToPagedResultAsync<T>(
        this IQueryable<T> query,
        int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        if (pageNumber <= 0) pageNumber = 1;
        if (pageSize <= 0) pageSize = 10;

        var itemsCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return PagedResult<T>.Create(items, pageNumber, pageSize, itemsCount);
    }

    public static IPagedResult<TDestination> Map<TSource, TDestination>(
        this IPagedResult<TSource> source,
        Func<TSource, TDestination> selector)
    {
        return PagedResult<TDestination>.Create(
            source.Items.Select(selector),
            source.PageNumber,
            source.PageSize,
            source.ItemsCount
        );
    }
}