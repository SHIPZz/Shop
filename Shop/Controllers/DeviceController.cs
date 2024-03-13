using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers;

public class DeviceController : Controller
{
    public IActionResult Device()
    {
        return View();
    }
}