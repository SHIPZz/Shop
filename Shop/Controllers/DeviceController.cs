using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Services;
using Microsoft.EntityFrameworkCore;
using Shop.Commands;

namespace Shop.Controllers
{
    [Route("api/device")]
    public class DeviceController : Controller
    {
        private readonly DeviceDatabaseService _deviceDatabaseService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private ILogger<DeviceModel> _logger;

        public DeviceController(IMapper mapper, IMediator mediator, DeviceDatabaseService deviceDatabaseService, ILogger<DeviceModel> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _deviceDatabaseService = deviceDatabaseService;
        }

        [HttpPost]
        public async Task<IActionResult> Device([FromBody] string selectedDevice)
        {
            _logger.LogInformation("Device controller: Device method called with selectedDevice: {selectedDevice}", selectedDevice);

            if (string.IsNullOrEmpty(selectedDevice))
            {
                _logger.LogWarning("Device controller: Selected device is null or empty.");
                return BadRequest("Selected device cannot be null or empty.");
            }

            try
            {
                var deviceModel =  _deviceDatabaseService.GetAll().FirstOrDefault(x => x.Name == selectedDevice);

                if (deviceModel == null)
                {
                    _logger.LogWarning("Device controller: Device not found.");
                    return NotFound("Device not found.");
                }

                AddOrderedDeviceModelCommand deviceModelCommand = _mapper.Map<AddOrderedDeviceModelCommand>(deviceModel);
                await _mediator.Send(deviceModelCommand);
                _logger.LogInformation("Device controller: Device added to cart successfully.");
                return Ok("Device added to cart successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Device controller: An error occurred while processing the request.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        public IActionResult Order()
        {
            return RedirectToAction("OrderDevice", "OrderedDevice");
        }

        [HttpGet]
        public IActionResult Device()
        {
            return View(_deviceDatabaseService.GetAll().ToList());
        }
    }
}