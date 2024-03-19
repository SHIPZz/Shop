using Microsoft.AspNetCore.Mvc;
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
        var isAdded = await _shoppingCartDatabaseService.Add(deviceId, userId);

        if (!isAdded)
            return NotFound("cart not found");

        return Ok($"{deviceId} added");
    }

    [HttpDelete]
    public async Task<IActionResult> Remove([FromQuery] int deviceId, [FromQuery] int userId)
    {
        var isRemoved = await _shoppingCartDatabaseService.Remove(deviceId, userId);
        
        if (!isRemoved)
            return NotFound("cart not found");

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