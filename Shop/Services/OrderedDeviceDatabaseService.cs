﻿using AutoMapper;
using Shop.Data;
using Shop.Models;

namespace Shop.Services;

public class OrderedDeviceDatabaseService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly BaseRepository<OrderedDeviceModel> _repository;
    private readonly ShoppingCartDatabaseService _shoppingCartDatabaseService;
    private DeviceDatabaseService _deviceDatabaseService;

    private IMapper _mapper;
    
    public OrderedDeviceModel OrderedDeviceModel { get; private set; }

    public OrderedDeviceDatabaseService(UnitOfWork unitOfWork, ShoppingCartDatabaseService shoppingCartDatabaseService,
        IMapper mapper, DeviceDatabaseService deviceDatabaseService)
    {
        _deviceDatabaseService = deviceDatabaseService;
        _shoppingCartDatabaseService = shoppingCartDatabaseService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = _unitOfWork.Resolve<BaseRepository<OrderedDeviceModel>, OrderedDeviceModel>();
    }

    public OrderedDeviceModel Get(int id) =>
        GetAll().FirstOrDefault(x => x.Id == id);

    public IEnumerable<OrderedDeviceModel> GetAll()
    {
        return _repository.GetAll();
    }

    public async Task Update(OrderedDeviceModel device)
    {
        await _repository.Update(device);
    }

    public async Task<bool> TryCreate(int userId)
    {
        var carts = _shoppingCartDatabaseService.GetByUserId(userId);

        if (carts.Count == 0)
            return false;
        
        foreach (ShoppingCartModel shoppingCartModel in carts)
        {
            DeviceModel deviceModel = _deviceDatabaseService.GetById(shoppingCartModel.DeviceId);
            var orderedDevice = _mapper.Map<OrderedDeviceModel>(deviceModel);
            orderedDevice.Count = _shoppingCartDatabaseService.GetDeviceCountById(userId, deviceModel.Id);
            orderedDevice.UserId = userId;
            OrderedDeviceModel = orderedDevice;

            if (_repository.GetAll().Contains(orderedDevice))
            {
                return true;
            }
            
            await _repository.Add(orderedDevice);
        }
        
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}