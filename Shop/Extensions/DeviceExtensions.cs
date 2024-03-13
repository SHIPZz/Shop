using Shop.Models;

namespace Shop.Extensions;

public static class DeviceExtensions
{
    public static OrderedDeviceModel ToOrdered(this DeviceModel deviceModel)
    {
        var orderedDevice = new OrderedDeviceModel()
        {
            Name = deviceModel.Name,
            Count = deviceModel.Count,
            Price = deviceModel.Price,
        };

        return orderedDevice;
    }
}