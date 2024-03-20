using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Services;

namespace Shop.Controllers;

[Route("api/cart")]
public class ShoppingCartController : ControllerBase
{
    private readonly ShoppingCartDatabaseService _shoppingCartDatabaseService;

    public ShoppingCartController(ShoppingCartDatabaseService shoppingCartDatabaseService)
    {
        _shoppingCartDatabaseService = shoppingCartDatabaseService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromQuery] int deviceId, [FromQuery] int userId)
    {
        await _shoppingCartDatabaseService.Add(deviceId, userId);

        return Ok($"{deviceId} + {_shoppingCartDatabaseService.GetByUserId(userId).Count} added");
    }

    [HttpDelete]
    public async Task<IActionResult> Remove([FromQuery] int deviceId, [FromQuery] int userId, [FromQuery] int count)
    {
        var isRemoved = await _shoppingCartDatabaseService.Remove(deviceId, userId, count);

        if (!isRemoved)
            return NotFound("couldn't remove");

        return Ok($"{deviceId} removed");
    }

    [HttpGet("{userId}")]
    public IActionResult GetByUserId(int userId)
    {
        var cart = _shoppingCartDatabaseService.GetByUserId(userId);

        if (cart == null)
            return NotFound("list is empty");

        return Ok(cart);
    }
}