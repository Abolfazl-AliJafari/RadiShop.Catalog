namespace RadiShop.Catalog.API.Endpoints.v1.Categories.Update;

public class UpdateCategoryEndpoint : BaseEndpoint<UpdateCategoryRequest>
{
    public override void Configure()
    {
        Put("/categories/");
        Validator<UpdateCategoryValidator>();
        AllowAnonymous();
        Description(p => p.WithTags("CategoryAPIs"));
        Version(1);
    }

    public override async Task HandleAsync(UpdateCategoryRequest req, CancellationToken ct)
    {
        var commandRequest  = req.ToCommand();
        await Sender.Send(commandRequest,ct);
        await Send.NoContentAsync(ct);
    }
}