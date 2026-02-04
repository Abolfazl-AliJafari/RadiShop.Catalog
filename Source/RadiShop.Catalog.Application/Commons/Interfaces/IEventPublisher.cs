namespace RadiShop.Catalog.Application.Commons.Interfaces;

public interface IEventPublisher
{
    Task PublishAsync<T>(T @event) where T : class;
}