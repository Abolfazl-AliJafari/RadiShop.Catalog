using FastEndpoints;
using MediatR;
using RadiShop.Catalog.API.Endpoints.v1.Categories;

namespace RadiShop.Catalog.API.Endpoints.v1;

public class BaseEndpoint<TRequest,TResponse> : Endpoint<TRequest,ApiResult<TResponse>> where TRequest : notnull
{
    private ISender _sender = null!;
    protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}

public class BaseEndpoint<TRequest> : Endpoint<TRequest,ApiResult> where TRequest : notnull
{
    private ISender _sender = null!;
    protected ISender Sender => _sender ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}