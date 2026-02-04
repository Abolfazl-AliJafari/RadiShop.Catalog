using RadiShop.Catalog.Shared.Types;

namespace RadiShop.Catalog.API.Endpoints.v1.Categories.GetAll;

public class GetAllCategoriesEndpoint : BaseEndpoint<GetAllCategoriesRequest, IPagedResult<GetAllCategoriesResponse>>
{
    public override void Configure()
    {
        Get("/categories/");
        AllowAnonymous();
        Description(p => p.WithTags("CategoryAPIs"));
        Version(1);
    }

    public override async Task HandleAsync(GetAllCategoriesRequest req, CancellationToken ct)
    {
        var commandRequest  = req.ToQuery();
        var result = await Sender.Send(commandRequest,ct);
        var mapped = PagedResult<GetAllCategoriesResponse>.Create(result.Items
            .Select(GetAllCategoriesResponse.FromQuery)
            .ToList(),result.PageNumber,result.PageSize,result.ItemsCount);
        var responseBody = ApiResult<IPagedResult<GetAllCategoriesResponse>>.Success(mapped);
        await Send.OkAsync(responseBody, ct);
    }
}