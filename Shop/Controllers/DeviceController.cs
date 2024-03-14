using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.Services;
using Microsoft.EntityFrameworkCore;
using Shop.Commands;

namespace Shop.Controllers
{
    public class DeviceController : Controller
    {
        private readonly DeviceDatabaseService _deviceDatabaseService;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DeviceController(IMapper mapper, IMediator mediator, DeviceDatabaseService deviceDatabaseService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _deviceDatabaseService = deviceDatabaseService;
        }

        [HttpPost]
        public async Task<IActionResult> Device(string selectedDevice)
        {
            DeviceModel deviceModel = _deviceDatabaseService.GetAll()
                .AsNoTracking()
                .FirstOrDefault(x => x.Name == selectedDevice);

            AddOrderedDeviceModelCommand deviceModelCommand = _mapper.Map<AddOrderedDeviceModelCommand>(deviceModel);
            await _mediator.Send(deviceModelCommand);
            
            return RedirectToAction("OrderDevice", "OrderedDevice");
        }

        [HttpGet]
        public IActionResult Device()
        {
            return View(_deviceDatabaseService.GetAll().ToList());
        }
    }
}