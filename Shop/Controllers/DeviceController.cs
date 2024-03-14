using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Services;

namespace Shop.Controllers;

public class DeviceController : Controller
{
    private readonly DeviceDatabaseService _deviceDatabaseService;
    private readonly OrderedDeviceDatabaseService _orderedDeviceDatabaseService;
    private readonly IMapper _mapper;

    public DeviceController(DeviceDatabaseService deviceDatabaseService, OrderedDeviceDatabaseService orderedDeviceDatabaseService,  IMapper mapper)
    {
        _mapper = mapper;
        _deviceDatabaseService = deviceDatabaseService;
        _orderedDeviceDatabaseService = orderedDeviceDatabaseService;
    }

    [HttpPost]
    public IActionResult Device(string selectedDevice)
    {
        DeviceModel deviceModel = _deviceDatabaseService.GetAll().FirstOrDefault(x => x.Name == selectedDevice);
        _orderedDeviceDatabaseService.OrderedDevice = _mapper.Map<OrderedDeviceModel>(deviceModel);
        return RedirectToAction("OrderDevice", "OrderedDevice");
    }
    
    [HttpGet]
    public IActionResult Device()
    {
        return View(_deviceDatabaseService.GetAll().ToList());
    }
}