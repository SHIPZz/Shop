using Microsoft.AspNetCore.Mvc;
using Shop.Services;

namespace Shop.Controllers;

public class DeviceController : Controller
{
    private readonly DeviceDatabaseService _deviceDatabaseService;

    public DeviceController(DeviceDatabaseService deviceDatabaseService)
    {
        _deviceDatabaseService = deviceDatabaseService;
    }

    public IActionResult Device()
    {
        return View(_deviceDatabaseService.GetAll().ToList());
    }
}