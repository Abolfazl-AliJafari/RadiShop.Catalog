namespace RadiShop.Catalog.API.Endpoints.v1.Brands.GetById;

public sealed class GetBrandByIdEndpoint : BaseEndpoint<GetBrandByIdRequest,GetBrandByIdResponse>
{
    public override void Configure()
    {
        Get("/brands/{brandId}/");
        AllowAnonymous();
        Description(p => p.WithTags("BrandAPIs"));
        Version(1);
    }

    public override async Task HandleAsync(GetBrandByIdRequest req, CancellationToken ct)
    {
        var commandRequest  = req.ToQuery();
        var result = await Sender.Send(commandRequest,ct);
        var mapped = GetBrandByIdResponse.FromQuery(result);
        var responseBody = ApiResult<GetBrandByIdResponse>.Success(mapped);
        await Send.OkAsync(responseBody, ct);
    }
}