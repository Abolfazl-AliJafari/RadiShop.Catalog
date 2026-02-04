namespace RadiShop.Catalog.API.Endpoints.v1.Categories.Create;

public class CreateCategoryEndpoint : BaseEndpoint<CreateCategoryRequest, CreateCategoryResponse>
{
    public override void Configure()
    {
        Post("/categories/");
        Validator<CreateCategoryValidator>();
        AllowAnonymous();
        Description(p => p.WithTags("CategoryAPIs"));
        Version(1);
    }

    public override async Task HandleAsync(CreateCategoryRequest req, CancellationToken ct)
    {
        var commandRequest  = req.ToCommand();
        var result = await Sender.Send(commandRequest,ct);
        var responseBody = ApiResult<CreateCategoryResponse>.Success(CreateCategoryResponse.FromCommand(result));
        await Send.CreatedAtAsync($"api/categories/{result.Id}/v1",responseBody:responseBody, cancellation: ct);
    }
}