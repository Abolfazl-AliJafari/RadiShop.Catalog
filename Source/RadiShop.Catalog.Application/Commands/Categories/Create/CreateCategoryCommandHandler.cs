using MediatR;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Domain.Entities;
using RadiShop.Catalog.Shared.Exceptions.CategoryExceptions;

namespace RadiShop.Catalog.Application.Commands.Categories.Create;

public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateCategoryCommandRequest,CreateCategoryCommandResponse>
{
    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        if (request.ParentId is not null)
        {
            var parentCategoryExist = await categoryRepository.AnyAsync(x => x.Id == request.ParentId,cancellationToken);
            if (!parentCategoryExist)
            {
                throw new ParentCategoryNotFoundException((Guid)request.ParentId);
            }
        }
        var titleExist = await categoryRepository.AnyAsync(x => x.Title == request.Title,cancellationToken);
        if (titleExist)
        {
            throw new CategoryAlreadyExistsException(request.Title);
        }
        var newCategory = Category.Create(request.Title, request.ParentId);
        categoryRepository.Add(newCategory);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateCategoryCommandResponse(newCategory.Id);   
    }
}