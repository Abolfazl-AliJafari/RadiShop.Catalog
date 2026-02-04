using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RadiShop.Catalog.Application.Commons.Interfaces;

namespace RadiShop.Catalog.Infrastructure.RabbitMq;

public static class ServicesConfigurations
{
    public static IServiceCollection AddRabbitMqServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration["AppSettings:RabbitMq:Host"], h =>
                {
                    h.Username(configuration["AppSettings:RabbitMq:Username"]!);
                    h.Password(configuration["AppSettings:RabbitMq:Password"]!);
                });

            });
        });
        services.AddScoped<IEventPublisher, RabbitMqEventPublisher>();
        return services;
    }
}