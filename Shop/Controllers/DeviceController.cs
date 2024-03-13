using Microsoft.AspNetCore.Mvc;
using Shop.Extensions;
using Shop.Models;
using Shop.Services;

namespace Shop.Controllers;

public class DeviceController : Controller
{
    private readonly DeviceDatabaseService _deviceDatabaseService;
    private readonly OrderedDeviceDatabaseService _orderedDeviceDatabaseService;

    public DeviceController(DeviceDatabaseService deviceDatabaseService, OrderedDeviceDatabaseService orderedDeviceDatabaseService)
    {
        _orderedDeviceDatabaseService = orderedDeviceDatabaseService;
        _deviceDatabaseService = deviceDatabaseService;
    }

    [HttpPost]
    public IActionResult Device(string selectedDevice)
    {
        DeviceModel target = _deviceDatabaseService.GetAll().FirstOrDefault(x => x.Name == selectedDevice);
        _orderedDeviceDatabaseService.OrderedDevice = target.ToOrdered();
        return RedirectToAction("OrderDevice", "OrderedDevice");
    }
    
    [HttpGet]
    public IActionResult Device()
    {
        return View(_deviceDatabaseService.GetAll().ToList());
    }
}