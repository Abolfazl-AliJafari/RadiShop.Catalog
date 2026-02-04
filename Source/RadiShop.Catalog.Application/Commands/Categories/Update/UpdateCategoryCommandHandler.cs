using MediatR;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Shared.Exceptions.CategoryExceptions;

namespace RadiShop.Catalog.Application.Commands.Categories.Update;

public class UpdateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateCategoryCommandRequest>
{
    public async Task Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var titleExist = await categoryRepository.AnyAsync(x => 
                x.Title == request.Title &&
                x.Id != request.CategoryId
            , cancellationToken);
        if (titleExist)
        {
            throw new CategoryAlreadyExistsException(request.Title);
        }

        var category = await categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);
        if (category is null)
        {
            throw new CategoryNotFoundException(request.CategoryId);
        }

        category.Update(request.Title);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}