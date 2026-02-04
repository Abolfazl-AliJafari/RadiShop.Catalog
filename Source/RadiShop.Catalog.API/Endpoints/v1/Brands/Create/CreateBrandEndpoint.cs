namespace RadiShop.Catalog.API.Endpoints.v1.Brands.Create;

public class CreateBrandEndpoint : BaseEndpoint<CreateBrandRequest, CreateBrandResponse>
{
    public override void Configure()
    {
        Post("/brands/");
        Validator<CreateBrandValidator>();
        AllowAnonymous();
        Description(p => p.WithTags("BrandAPIs"));
        Version(1);
    }

    public override async Task HandleAsync(CreateBrandRequest req, CancellationToken ct)
    {
        var commandRequest  = req.ToCommand();
        var result = await Sender.Send(commandRequest,ct);
        var responseBody = ApiResult<CreateBrandResponse>.Success(CreateBrandResponse.FromCommand(result));
        await Send.CreatedAtAsync($"api/brands/{result.Id}/v1",responseBody:responseBody, cancellation: ct);
    }
}