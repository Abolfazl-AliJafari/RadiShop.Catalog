using MediatR;
using RadiShop.Catalog.Application.Commons;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Shared.Types;

namespace RadiShop.Catalog.Application.Queries.Brands.GetAll;

public class GetAllBrandsQueryHandler(IBrandRepository brandRepository) : IRequestHandler<GetAllBrandsQueryRequest,IPagedResult<GetAllBrandsQueryResponse>>
{
    public async Task<IPagedResult<GetAllBrandsQueryResponse>> Handle(GetAllBrandsQueryRequest request, CancellationToken cancellationToken)
    {
        var brands = await brandRepository.GetAllAsync<GetAllBrandsQueryResponse>(cancellationToken,
            x=> GetAllBrandsQueryResponse.FromEntity(x),
            request.PageNumber,
            request.PageSize,
            orderByDescending:false,
            orderBy:x => x.Title);
        if (brands == null) return PagedResult<GetAllBrandsQueryResponse>.Create(
            new List<GetAllBrandsQueryResponse>(),
            0,
            0,
            0);
        return brands;
    }
}