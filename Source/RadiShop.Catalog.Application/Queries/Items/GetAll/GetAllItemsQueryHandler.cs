using MediatR;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Shared.Types;

namespace RadiShop.Catalog.Application.Queries.Items.GetAll;

public class GetAllItemsQueryHandler(IItemRepository itemRepository) : IRequestHandler<GetAllItemsQueryRequest,IPagedResult<GetAllItemsQueryResponse>>
{
    public async Task<IPagedResult<GetAllItemsQueryResponse>> Handle(GetAllItemsQueryRequest request, CancellationToken cancellationToken)
    {
        var items = await itemRepository.GetAllAsync<GetAllItemsQueryResponse>(cancellationToken,
            x=> GetAllItemsQueryResponse.FromEntity(x),
            request.PageNumber,
            request.PageSize,
            orderByDescending:false,
            orderBy:x => x.Name,
            includes:[x=>x.Brand,x=>x.Category]);
        if (items == null) return PagedResult<GetAllItemsQueryResponse>.Create(
            new List<GetAllItemsQueryResponse>(),
            0,
            0,
            0);
        return items;
    }
}