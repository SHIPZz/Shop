using MediatR;
using Shop.Models;

namespace Shop.Commands;

public class AddOrderedDeviceModelCommand : IRequest<OrderedDeviceModel>
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string ImagePath { get; set; }

    public float Price { get; set; }

    public int Count { get; set; }
}