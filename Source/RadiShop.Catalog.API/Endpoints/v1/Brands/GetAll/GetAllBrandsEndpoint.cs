using RadiShop.Catalog.Shared.Types;

namespace RadiShop.Catalog.API.Endpoints.v1.Brands.GetAll;

public class GetAllBrandsEndpoint : BaseEndpoint<GetAllBrandsRequest, IPagedResult<GetAllBrandsResponse>>
{
    public override void Configure()
    {
        Get("/brands/");
        AllowAnonymous();
        Description(p => p.WithTags("BrandAPIs"));
        Version(1);
    }

    public override async Task HandleAsync(GetAllBrandsRequest req, CancellationToken ct)
    {
        var commandRequest  = req.ToQuery();
        var result = await Sender.Send(commandRequest,ct);
        var mapped = PagedResult<GetAllBrandsResponse>.Create(result.Items
                .Select(GetAllBrandsResponse.FromQuery)
                .ToList(),result.PageNumber,result.PageSize,result.ItemsCount);
        var responseBody = ApiResult<IPagedResult<GetAllBrandsResponse>>.Success(mapped);
        await Send.OkAsync(responseBody, ct);
    }
}