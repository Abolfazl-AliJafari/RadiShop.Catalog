using RadiShop.Catalog.API.Endpoints.v1.Categories.GetById;

namespace RadiShop.Catalog.API.Endpoints.v1.Items.GetById;

public sealed class GetItemByIdEndpoint : BaseEndpoint<GetItemByIdRequest,GetItemByIdResponse>
{
    public override void Configure()
    {
        Get("/items/{itemSlug}/");
        AllowAnonymous();
        Description(p => p.WithTags("ItemAPIs"));
        Version(1);
    }

    public override async Task HandleAsync(GetItemByIdRequest req, CancellationToken ct)
    {
        var commandRequest  = req.ToQuery();
        var result = await Sender.Send(commandRequest,ct);
        var mapped = GetItemByIdResponse.FromQuery(result);
        var responseBody = ApiResult<GetItemByIdResponse>.Success(mapped);
        await Send.OkAsync(responseBody, ct);
    }
}