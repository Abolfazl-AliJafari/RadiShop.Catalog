namespace RadiShop.Catalog.Application.Commons.Interfaces;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}