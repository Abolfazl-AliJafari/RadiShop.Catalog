using MediatR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using NJsonSchema;
using RadiShop.Catalog.Application.Commons.IntegrationsEvents;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Domain.Entities;
using RadiShop.Catalog.Shared;
using RadiShop.Catalog.Shared.Exceptions.BrandExceptions;
using RadiShop.Catalog.Shared.Exceptions.CategoryExceptions;
using RadiShop.Catalog.Shared.Exceptions.ItemExceptions;

namespace RadiShop.Catalog.Application.Commands.Items.Create;

public class CreateItemCommandHandler(IItemRepository itemRepository,
    ICategoryRepository categoryRepository,
    IBrandRepository brandRepository,
    IUnitOfWork unitOfWork,
    IEventPublisher eventPublisher,
    IOptions<AppSettings> options) : IRequestHandler<CreateItemCommandRequest,CreateItemCommandResponse>
{
    private readonly AppSettings _settings = options.Value;
    public async Task<CreateItemCommandResponse> Handle(CreateItemCommandRequest request, CancellationToken cancellationToken)
    {
        var brandExist = await brandRepository.AnyAsync(x => x.Id == request.BrandId,cancellationToken);
        if (!brandExist)
        {
            throw new BrandNotFoundException(request.BrandId);
        }
        
        var categoryExist = await categoryRepository.AnyAsync(x => x.Id == request.CategoryId,cancellationToken);
        if (!categoryExist)
        {
            throw new CategoryNotFoundException(request.CategoryId);
        }
        
        var titleExist = await itemRepository.AnyAsync(x => x.Name == request.Name,cancellationToken);
        if (titleExist)
        {
            throw new ItemAlreadyExistsException(request.Name);
        }
        
        var newItem = Item.Create(request.Name,request.Description,request.MaxStockThreshold,request.BrandId,request.CategoryId);
        itemRepository.Add(newItem);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        var item = await itemRepository.GetByIdAsync(newItem.Slug, cancellationToken, x => x.Category, x=>x.Brand);
        if (item == null)
            throw new ItemNotFoundException(newItem.Slug);
        //send event
        var evt = new CatalogItemAddedEvent(
            Version: 1,
            EventType: "CatalogItemAdded",
            Timestamp: DateTime.UtcNow,
            Data: new CatalogItemAddedData(
                item.Name,
                item.Description??string.Empty,
                item.Category.Title,
                item.Brand.Title,
                item.Slug,
                $"{_settings.ApiGateway.BaseUrl}/catalog/items/{newItem.Slug}"
            )
        );
        
        var schema = await JsonSchema.FromFileAsync(SchemaPaths.CatalogItemAddedEventV1, cancellationToken);
        var evtJObject = JObject.FromObject(evt);
        var errors = schema.Validate(evtJObject);
        if(errors.Count != 0)
        {
            throw new InvalidOperationException("Event validation failed: " + string.Join(",", errors.Select(e=>e.ToString())));
        }

        await eventPublisher.PublishAsync(evt);
        return new CreateItemCommandResponse(newItem.Slug);   
    }
}