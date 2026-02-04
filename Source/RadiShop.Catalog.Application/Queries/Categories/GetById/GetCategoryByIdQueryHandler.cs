using MediatR;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Shared.Exceptions.CategoryExceptions;

namespace RadiShop.Catalog.Application.Queries.Categories.GetById;

public class GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<GetCategoryByIdQueryRequest,GetCategoryByIdQueryResponse>
{
    public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdAsync(request.CategoryId,cancellationToken);
        if (category is null)
        {
            throw new CategoryNotFoundException(request.CategoryId);
        }
        return GetCategoryByIdQueryResponse.FromEntity(category);
    }
}