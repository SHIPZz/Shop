using Domain.Shop.Entity;
using Microsoft.AspNetCore.Mvc;
using Shop.Services;

namespace Shop.Controllers;

public class AuthorizationController : Controller
{
    private readonly UserService _userService;

    public AuthorizationController(UserService userService)
    {
        _userService = userService;
    }

    public IActionResult Authorize()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Authorize(UserViewModel userViewModel)
    {
        var hasUser = _userService.HasUser(userViewModel.Email);

        if (!hasUser)
        {
            ViewBag.HasUser = false;
            return View(new UserViewModel());
        }

        ViewBag.HasUser = true;
        return RedirectToAction("GetById", "Device");
    }
}