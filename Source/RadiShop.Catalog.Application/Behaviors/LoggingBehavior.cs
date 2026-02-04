using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace RadiShop.Catalog.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(
    ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger = logger;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var stopwatch = Stopwatch.StartNew();

        _logger.LogInformation(
            "CatalogService handling request {RequestName} with payload: {@Request}",
            requestName,
            request);

        try
        {
            var response = await next();

            stopwatch.Stop();

            _logger.LogInformation(
                "CatalogService handled request {RequestName} in {ElapsedMilliseconds}ms with response: {@Response}",
                requestName,
                stopwatch.ElapsedMilliseconds,
                response);

            return response;
        }
        catch (Exception ex)
        {
            stopwatch.Stop();

            _logger.LogError(
                ex,
                "CatalogService error handling request {RequestName} after {ElapsedMilliseconds}ms. Payload: {@Request}",
                requestName,
                stopwatch.ElapsedMilliseconds,
                request);

            throw;
        }
    }
}