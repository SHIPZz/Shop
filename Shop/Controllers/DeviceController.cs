using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Services;
using Microsoft.EntityFrameworkCore;
using Shop.Commands;

namespace Shop.Controllers
{
    [Route("api/devices")]
    public class DeviceController : ControllerBase
    {
        private readonly DeviceDatabaseService _deviceDatabaseService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private ILogger<DeviceModel> _logger;

        public DeviceController(IMapper mapper, IMediator mediator, DeviceDatabaseService deviceDatabaseService,
            ILogger<DeviceModel> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _deviceDatabaseService = deviceDatabaseService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var deviceModel = _deviceDatabaseService.GetAll().Find(x => x.Id == id);

                _logger.LogError($"{id} + {deviceModel}");
        
                if (deviceModel == null)
                {
                    _logger.LogWarning("Device controller: Device not found.");
                    return NotFound("Device not found.");
                }
        
                AddOrderedDeviceModelCommand deviceModelCommand = _mapper.Map<AddOrderedDeviceModelCommand>(deviceModel);
                await _mediator.Send(deviceModelCommand);
                return Ok($"Device is found succesfully: {deviceModel}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Device controller: An error occurred while processing the request.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpGet("search")]
        public IActionResult SearchByQuery(string query)
        {
            var device = _deviceDatabaseService.GetAll()
                .Find(x => x.Name == query);

            if (device == null)
            {
                return NotFound("There is no device");
            }

            return Ok(device);
        }


        [HttpGet]
        public IActionResult GetAllDevices() =>
            Ok(_deviceDatabaseService.GetAll());
    }
}