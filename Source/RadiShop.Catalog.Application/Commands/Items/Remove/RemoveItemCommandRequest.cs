using MediatR;

namespace RadiShop.Catalog.Application.Commands.Items.Remove;

public sealed record RemoveItemCommandRequest(string Slug) : IRequest;