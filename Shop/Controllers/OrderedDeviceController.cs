using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Services;

namespace Shop.Controllers
{
    public class OrderedDeviceController : Controller
    {
        private readonly OrderedDeviceDatabaseService _orderedDeviceDatabaseService;

        public OrderedDeviceController(OrderedDeviceDatabaseService orderedDeviceDatabaseService)
        {
            _orderedDeviceDatabaseService = orderedDeviceDatabaseService;
        }

        public IActionResult OrderDevice()
        {
            var orderedDevices = _orderedDeviceDatabaseService.GetAll().ToList();
            return View(orderedDevices);
        }

        [HttpPost]
        public async Task<IActionResult> IncreaseCount(int id)
        {
            var device = _orderedDeviceDatabaseService.Get(id);

            if (device != null)
            {
                device.Count++;
                await _orderedDeviceDatabaseService.Update(device);
            }

            return RedirectToAction("OrderDevice");
        }

        [HttpPost]
        public async Task<IActionResult> DecreaseCount(int id)
        {
            OrderedDeviceModel? device = _orderedDeviceDatabaseService.Get(id);
            
            if (device != null && device.Count > 0)
            {
                device.Count--;
               await _orderedDeviceDatabaseService.Update(device);
            }

            return RedirectToAction("OrderDevice");
        }
    }
}