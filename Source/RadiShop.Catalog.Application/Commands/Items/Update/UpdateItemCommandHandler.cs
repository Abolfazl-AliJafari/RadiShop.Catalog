using MediatR;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Shared.Exceptions.BrandExceptions;
using RadiShop.Catalog.Shared.Exceptions.CategoryExceptions;
using RadiShop.Catalog.Shared.Exceptions.ItemExceptions;

namespace RadiShop.Catalog.Application.Commands.Items.Update;

public class UpdateItemCommandHandler(
    IItemRepository itemRepository,
    IBrandRepository brandRepository,
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateItemCommandRequest>
{
    public async Task Handle(UpdateItemCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await itemRepository.GetByIdAsync(request.Slug, cancellationToken);
        if (item is null)
        {
            throw new ItemNotFoundException(request.Slug);
        }

        if (item.BrandId != request.BrandId)
        {
            var brandExists = await brandRepository.AnyAsync(x => x.Id == request.BrandId, cancellationToken);
            if (!brandExists)
            {
                throw new BrandNotFoundException(request.BrandId);
            }
        }
        if (item.CategoryId != request.CategoryId)
        {
            var categoryExists = await categoryRepository.AnyAsync(x => x.Id == request.CategoryId, cancellationToken);
            if (!categoryExists)
            {
                throw new CategoryNotFoundException(request.CategoryId);
            }
        }
        item.Update(request.Description,request.BrandId,request.CategoryId);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}