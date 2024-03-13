using Microsoft.AspNetCore.Mvc;
using Shop.Services;

namespace Shop.Controllers;

public class OrderedDeviceController : Controller
{
    private readonly OrderedDeviceDatabaseService _orderedDeviceDatabaseService;

    public OrderedDeviceController(OrderedDeviceDatabaseService orderedDeviceDatabaseService)
    {
        _orderedDeviceDatabaseService = orderedDeviceDatabaseService;
    }

    public IActionResult OrderDevice()
    {
        return View(_orderedDeviceDatabaseService.OrderedDevice);
    }
}