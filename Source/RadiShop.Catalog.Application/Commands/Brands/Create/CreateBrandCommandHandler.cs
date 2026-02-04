using MediatR;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Domain.Entities;
using RadiShop.Catalog.Shared.Exceptions.BrandExceptions;
using RadiShop.Catalog.Shared.Exceptions.CategoryExceptions;

namespace RadiShop.Catalog.Application.Commands.Brands.Create;

public class CreateBrandCommandHandler(IBrandRepository brandRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateBrandCommandRequest,CreateBrandCommandResponse>
{
    public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommandRequest request, CancellationToken cancellationToken)
    {
        var titleExist = await brandRepository.AnyAsync(x => x.Title == request.Title,cancellationToken);
        if (titleExist)
        {
            throw new BrandAlreadyExistsException(request.Title);
        }
        var newBrand = Brand.Create(request.Title);
        brandRepository.Add(newBrand);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateBrandCommandResponse(newBrand.Id);   
    }
}