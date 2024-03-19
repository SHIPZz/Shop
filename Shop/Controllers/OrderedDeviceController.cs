using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Services;

namespace Shop.Controllers
{
    [Route("api/orders")]
    public class OrderedDeviceController : Controller
    {
        private readonly OrderedDeviceDatabaseService _orderedDeviceDatabaseService;

        public OrderedDeviceController(OrderedDeviceDatabaseService orderedDeviceDatabaseService)
        {
            _orderedDeviceDatabaseService = orderedDeviceDatabaseService;
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> Create(int userId)
        {
            OrderedDeviceModel? model = await _orderedDeviceDatabaseService.TryCreate(userId);
            return Ok(model);
        }
    }
}