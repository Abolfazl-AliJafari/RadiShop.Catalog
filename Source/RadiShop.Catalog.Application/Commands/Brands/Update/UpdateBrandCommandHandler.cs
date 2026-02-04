using MediatR;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Shared.Exceptions.BrandExceptions;

namespace RadiShop.Catalog.Application.Commands.Brands.Update;

public class UpdateBrandCommandHandler(
    IBrandRepository brandRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateBrandCommandRequest>
{
    public async Task Handle(UpdateBrandCommandRequest request, CancellationToken cancellationToken)
    {
        var titleExist = await brandRepository.AnyAsync(x => 
                x.Title == request.Title &&
                x.Id != request.BrandId
            , cancellationToken);
        if (titleExist)
        {
            throw new BrandAlreadyExistsException(request.Title);
        }

        var brand = await brandRepository.GetByIdAsync(request.BrandId, cancellationToken);
        if (brand is null)
        {
            throw new BrandNotFoundException(request.BrandId);
        }

        brand.Update(request.Title);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}