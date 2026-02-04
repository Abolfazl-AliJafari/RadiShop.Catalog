using MediatR;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Shared.Exceptions.BrandExceptions;

namespace RadiShop.Catalog.Application.Queries.Brands.GetById;

public class GetBrandByIdQueryHandler(IBrandRepository brandRepository) : IRequestHandler<GetBrandByIdQueryRequest,GetBrandByIdQueryResponse>
{
    public async Task<GetBrandByIdQueryResponse> Handle(GetBrandByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var category = await brandRepository.GetByIdAsync(request.CategoryId,cancellationToken);
        if (category is null)
        {
            throw new BrandNotFoundException(request.CategoryId);
        }
        return GetBrandByIdQueryResponse.FromEntity(category);
    }
}