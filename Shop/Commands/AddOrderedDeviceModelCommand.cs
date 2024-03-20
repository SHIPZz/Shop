using Domain.Shop.Entity;
using MediatR;

namespace Shop.Commands;

public class AddOrderedDeviceModelCommand : IRequest<OrderedDeviceModel>
{
    public int Id { get; set; }
    public int UserId { get; set; }
}