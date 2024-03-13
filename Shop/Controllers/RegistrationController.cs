using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Services;

namespace Shop.Controllers;

public class RegistrationController : Controller
{
    private readonly UserDatabaseService _userDatabaseService;

    public RegistrationController(UserDatabaseService userDatabaseService)
    {
        _userDatabaseService = userDatabaseService;
    }

    public IActionResult Register()
    {
        return View(new UserViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Register(UserViewModel userViewModel)
    {
        var isUserCreated = await _userDatabaseService.TryCreate(userViewModel);
        
        if (!isUserCreated)
        {
            ViewBag.IsRegistrationSucceded = false;
            return View(new UserViewModel());
        }
        
        ViewBag.IsRegistrationSucceded = true;
        return RedirectToAction("Authorize", "Authorization");
    }
}