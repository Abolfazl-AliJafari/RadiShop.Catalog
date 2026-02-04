using MediatR;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Domain.Entities;
using RadiShop.Catalog.Shared.Types;

namespace RadiShop.Catalog.Application.Queries.Categories.GetAll;

public class GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetAllCategoriesQueryRequest,IPagedResult<GetAllCategoriesQueryResponse>>
{
    public async Task<IPagedResult<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAllAsync<GetAllCategoriesQueryResponse>(cancellationToken,
            x=> GetAllCategoriesQueryResponse.FromEntity(x),
            request.PageNumber,
            request.PageSize,
            orderByDescending:false,
            orderBy:x => x.Title);
        if (categories == null)
            return PagedResult<GetAllCategoriesQueryResponse>.Create(
                new List<GetAllCategoriesQueryResponse>(),
                0,
                0,
                0);
        return categories;
    }
}