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

        [HttpPut("{orderId}")]
        public async Task<IActionResult> Pay(int orderId)
        {
          var isSet =  await _orderedDeviceDatabaseService.SetPurchased(orderId);

          if (!isSet)
              return NotFound("is purchased not set");

          return Ok($"{_orderedDeviceDatabaseService.OrderedDeviceModel.Name} is purchased");
        }

        [HttpGet("{userId}")]
        public IActionResult GetAllOrderedDevices(int userId)
        {
           return Ok(_orderedDeviceDatabaseService.GetAll(userId));
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> Create(int userId)
        {
            var isCreated = await _orderedDeviceDatabaseService.TryCreate(userId);

            if (!isCreated)
            {
                return NotFound("Not created");
            }
            
            return Ok($"{_orderedDeviceDatabaseService.OrderedDeviceModel.Name} created");
        }
    }
}