namespace RadiShop.Catalog.API.Endpoints.v1.Categories.Remove;

public class RemoveCategoryEndpoint : BaseEndpoint<RemoveCategoryRequest>
{
    public override void Configure()
    {
        Delete("/categories/{categoryId}/");
        Validator<RemoveCategoryValidator>();
        AllowAnonymous();
        Description(p => p.WithTags("CategoryAPIs"));
        Version(1);
    }

    public override async Task HandleAsync(RemoveCategoryRequest req, CancellationToken ct)
    {
        var commandRequest  = req.ToCommand();
        await Sender.Send(commandRequest,ct);
        await Send.NoContentAsync(ct);
    }
}