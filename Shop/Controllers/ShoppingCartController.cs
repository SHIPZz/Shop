using Application.Shop.Services;
using Microsoft.AspNetCore.Mvc;
using Shop.Services;

namespace Shop.Controllers;

[Route("api/cart")]
public class ShoppingCartController : ControllerBase
{
    private readonly ShoppingCartService _shoppingCartService;

    public ShoppingCartController(ShoppingCartService shoppingCartService)
    {
        _shoppingCartService = shoppingCartService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromQuery] int deviceId, [FromQuery] int userId)
    {
        await _shoppingCartService.Add(deviceId, userId);

        return Ok($"{deviceId} + {_shoppingCartService.GetByUserId(userId).Count} added");
    }

    [HttpDelete]
    public async Task<IActionResult> Remove([FromQuery] int deviceId, [FromQuery] int userId, [FromQuery] int count)
    {
        var isRemoved = await _shoppingCartService.Remove(deviceId, userId, count);

        if (!isRemoved)
            return NotFound("couldn't remove");

        return Ok($"{deviceId} removed");
    }

    [HttpGet("{userId}")]
    public IActionResult GetByUserId(int userId)
    {
        var cart = _shoppingCartService.GetByUserId(userId);

        if (cart == null)
            return NotFound("list is empty");

        return Ok(cart);
    }
}