using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Services;

namespace Shop.Controllers
{
    [Route("api/orders")]
    public class OrderedDeviceController : Controller
    {
        private readonly OrderedDeviceService _orderedDeviceService;

        public OrderedDeviceController(OrderedDeviceService orderedDeviceService)
        {
            _orderedDeviceService = orderedDeviceService;
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> Pay(int orderId)
        {
          var isSet =  await _orderedDeviceService.SetPurchased(orderId);

          if (!isSet)
              return NotFound("is purchased not set");

          return Ok($"{_orderedDeviceService.OrderedDeviceModel.Name} is purchased");
        }

        [HttpGet("{userId}")]
        public IActionResult GetAllOrderedDevices(int userId)
        {
           return Ok(_orderedDeviceService.GetAll(userId));
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> Create(int userId)
        {
            var isCreated = await _orderedDeviceService.TryCreate(userId);

            if (!isCreated)
            {
                return NotFound("Not created");
            }
            
            return Ok($"{_orderedDeviceService.OrderedDeviceModel.Name} created");
        }
    }
}