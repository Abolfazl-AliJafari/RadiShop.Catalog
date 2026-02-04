using MassTransit;
using RadiShop.Catalog.Application.Commons.Interfaces;

namespace RadiShop.Catalog.Infrastructure.RabbitMq;

public class RabbitMqEventPublisher(IPublishEndpoint publishEndpoint) : IEventPublisher
{
    public async Task PublishAsync<T>(T @event) where T : class
    {
        await publishEndpoint.Publish(@event);
    }
}