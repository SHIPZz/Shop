using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Services;

namespace Shop.Controllers;

public class RegistrationController : Controller
{
    private readonly UserService _userService;

    public RegistrationController(UserService userService)
    {
        _userService = userService;
    }

    public IActionResult Register()
    {
        return View(new UserViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserViewModel userViewModel)
    {
        var isUserCreated = await _userService.TryCreate(userViewModel);
        
        if (!isUserCreated)
        {
            ViewBag.IsRegistrationSucceded = false;
            return View(new UserViewModel());
        }
        
        ViewBag.IsRegistrationSucceded = true;
        return RedirectToAction("Authorize", "Authorization");
    }
}