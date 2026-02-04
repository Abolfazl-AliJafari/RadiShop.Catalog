using MediatR;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Shared.Exceptions.CategoryExceptions;

namespace RadiShop.Catalog.Application.Commands.Categories.Remove;

public class RemoveCategoryCommandHandler(ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemoveCategoryCommandRequest>
{
    public async Task Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken,x => x.Childrens);
        if (category is null)
        {
            throw new CategoryNotFoundException(request.CategoryId);
        }

        if (category.Childrens.Count != 0)
        {
            throw new CategoryHasChildrenException(request.CategoryId);
        }
        
        categoryRepository.Remove(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}