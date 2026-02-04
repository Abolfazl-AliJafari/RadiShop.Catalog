namespace RadiShop.Catalog.API.Endpoints.v1.Brands.Update;

public class UpdateBrandEndpoint : BaseEndpoint<UpdateBrandRequest>
{
    public override void Configure()
    {
        Put("/brands/");
        Validator<UpdateBrandValidator>();
        AllowAnonymous();
        Description(p => p.WithTags("BrandAPIs"));
        Version(1);
    }

    public override async Task HandleAsync(UpdateBrandRequest req, CancellationToken ct)
    {
        var commandRequest  = req.ToCommand();
        await Sender.Send(commandRequest,ct);
        await Send.NoContentAsync(ct);
    }
}