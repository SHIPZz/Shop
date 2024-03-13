using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Services;

namespace Shop.Controllers;

public class AuthorizationController : Controller
{
    private readonly UserDatabaseService _userDatabaseService;

    public AuthorizationController(UserDatabaseService userDatabaseService)
    {
        _userDatabaseService = userDatabaseService;
    }

    public IActionResult Authorize()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Authorize(UserViewModel userViewModel)
    {
        var hasUser = _userDatabaseService.HasUser(userViewModel.Password);

        if (!hasUser)
        {
            ViewBag.HasUser = false;
            return View(new UserViewModel());
        }

        ViewBag.HasUser = true;
        return View();
    }
}