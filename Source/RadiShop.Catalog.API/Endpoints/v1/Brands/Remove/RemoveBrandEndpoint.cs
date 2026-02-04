namespace RadiShop.Catalog.API.Endpoints.v1.Brands.Remove;

public class RemoveBrandEndpoint : BaseEndpoint<RemoveBrandRequest>
{
    public override void Configure()
    {
        Delete("/brands/{brandId}/");
        Validator<RemoveBrandValidator>();
        AllowAnonymous();
        Description(p => p.WithTags("BrandAPIs"));
        Version(1);
    }

    public override async Task HandleAsync(RemoveBrandRequest req, CancellationToken ct)
    {
        var commandRequest  = req.ToCommand();
        await Sender.Send(commandRequest,ct);
        await Send.NoContentAsync(ct);
    }
}