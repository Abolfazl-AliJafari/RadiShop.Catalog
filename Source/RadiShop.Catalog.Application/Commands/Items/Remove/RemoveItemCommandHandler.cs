using MediatR;
using RadiShop.Catalog.Application.Commons.Interfaces;
using RadiShop.Catalog.Shared.Exceptions.ItemExceptions;

namespace RadiShop.Catalog.Application.Commands.Items.Remove;

public class RemoveItemCommandHandler(IItemRepository itemRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<RemoveItemCommandRequest>
{
    public async Task Handle(RemoveItemCommandRequest request, CancellationToken cancellationToken)
    {
        var item = await itemRepository.GetByIdAsync(request.Slug, cancellationToken);
        if (item is null)
        {
            throw new ItemNotFoundException(request.Slug);
        }
        itemRepository.Remove(item);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}