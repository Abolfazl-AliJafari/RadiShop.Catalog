using MediatR;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Shared.Exceptions.ItemExceptions;

namespace RadiShop.Catalog.Application.Queries.Items.GetById;

public class GetItemByIdQueryHandler(IItemRepository itemRepository) : IRequestHandler<GetItemByIdQueryRequest,GetItemByIdQueryResponse>
{
    public async Task<GetItemByIdQueryResponse> Handle(GetItemByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var item = await itemRepository.GetByIdAsync(request.Slug,cancellationToken,includes:[x=>x.Category,x => x.Brand]);
        if (item is null)
        {
            throw new ItemNotFoundException(request.Slug);
        }
        return GetItemByIdQueryResponse.FromEntity(item);
    }
}