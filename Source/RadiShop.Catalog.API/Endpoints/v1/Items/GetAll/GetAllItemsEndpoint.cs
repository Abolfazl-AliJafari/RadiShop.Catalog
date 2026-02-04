using RadiShop.Catalog.Shared.Types;

namespace RadiShop.Catalog.API.Endpoints.v1.Items.GetAll;

public class GetAllItemsEndpoint : BaseEndpoint<GetAllItemsRequest, IPagedResult<GetAllItemsResponse>>
{
    public override void Configure()
    {
        Get("/items/");
        AllowAnonymous();
        Description(p => p.WithTags("ItemAPIs"));
        Version(1);
    }

    public override async Task HandleAsync(GetAllItemsRequest req, CancellationToken ct)
    {
        var commandRequest  = req.ToQuery();
        var result = await Sender.Send(commandRequest,ct);
        var mapped = PagedResult<GetAllItemsResponse>.Create(result.Items
            .Select(GetAllItemsResponse.FromQuery)
            .ToList(),result.PageNumber,result.PageSize,result.ItemsCount);
        var responseBody = ApiResult<IPagedResult<GetAllItemsResponse>>.Success(mapped);
        await Send.OkAsync(responseBody, ct);
    }
}