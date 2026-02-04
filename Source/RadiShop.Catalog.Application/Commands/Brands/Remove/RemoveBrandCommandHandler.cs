using MediatR;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Shared.Exceptions.BrandExceptions;

namespace RadiShop.Catalog.Application.Commands.Brands.Remove;

public class RemoveBrandCommandHandler(IBrandRepository brandRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemoveBrandCommandRequest>
{
    public async Task Handle(RemoveBrandCommandRequest request, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.GetByIdAsync(request.BrandId, cancellationToken);
        if (brand is null)
        {
            throw new BrandNotFoundException(request.BrandId);
        }
        
        brandRepository.Remove(brand);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}