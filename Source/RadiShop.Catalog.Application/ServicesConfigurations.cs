using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RadiShop.Catalog.Application.Behaviors;

namespace RadiShop.Catalog.Application;

public static class ServicesConfigurations
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            //cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        });
        return services;
    }
}