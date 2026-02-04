using Microsoft.AspNetCore.Diagnostics;
using RadiShop.Catalog.API.Endpoints.v1;
using RadiShop.Catalog.Shared.Exceptions;

namespace RadiShop.Catalog.API.Middlewares;

internal sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly Dictionary<Type, Func<HttpContext, Exception, CancellationToken, Task>> _exceptionHandlers;
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
        _exceptionHandlers = new()
        {
            { typeof(CatalogDomainException), HandleCatalogDomainException },
        };
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "An exception occurred: {Message}", exception.Message);

        var handler = _exceptionHandlers
            .FirstOrDefault(h => h.Key.IsAssignableFrom(exception.GetType()))
            .Value;

        if (handler == null)
            return await HandleUnknownException(httpContext, exception, cancellationToken);
        await handler(httpContext, exception, cancellationToken);
        return true;
    }

    private async Task HandleCatalogDomainException(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        var apiResult = ApiResult.Failure(exception.Message);

        await WriteApiResultAsync(httpContext, apiResult, 400, cancellationToken);
    }

    private async Task<bool> HandleUnknownException(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        var apiResult = ApiResult.Failure(exception.Message);

        await WriteApiResultAsync(httpContext, apiResult, 500, cancellationToken);
        return false;
    }

    private static async Task WriteApiResultAsync(HttpContext httpContext, ApiResult apiResult, int? statusCode,
        CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = statusCode ?? StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(apiResult, cancellationToken);
    }
}