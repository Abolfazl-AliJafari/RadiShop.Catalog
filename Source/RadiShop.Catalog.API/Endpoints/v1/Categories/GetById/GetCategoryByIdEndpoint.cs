namespace RadiShop.Catalog.API.Endpoints.v1.Categories.GetById;

public sealed class GetCategoryByIdEndpoint : BaseEndpoint<GetCategoryByIdRequest,GetCategoryByIdResponse>
{
    public override void Configure()
    {
        Get("/categories/{categoryId}/");
        AllowAnonymous();
        Description(p => p.WithTags("CategoryAPIs"));
        Version(1);
    }

    public override async Task HandleAsync(GetCategoryByIdRequest req, CancellationToken ct)
    {
        var commandRequest  = req.ToQuery();
        var result = await Sender.Send(commandRequest,ct);
        var mapped = GetCategoryByIdResponse.FromQuery(result);
        var responseBody = ApiResult<GetCategoryByIdResponse>.Success(mapped);
        await Send.OkAsync(responseBody, ct);
    }
}