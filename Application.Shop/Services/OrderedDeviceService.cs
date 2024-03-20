using AutoMapper;
using DAL.Shop;
using Domain.Shop.Entity;
using Shop.Services;

namespace Application.Shop.Services;

public class OrderedDeviceService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly BaseRepository<OrderedDeviceModel> _repository;
    private readonly ShoppingCartService _shoppingCartService;
    private readonly DeviceService _deviceService;

    private readonly IMapper _mapper;
    
    public OrderedDeviceModel OrderedDeviceModel { get; private set; }

    public OrderedDeviceService(UnitOfWork unitOfWork, ShoppingCartService shoppingCartService,
        IMapper mapper, DeviceService deviceService)
    {
        _deviceService = deviceService;
        _shoppingCartService = shoppingCartService;
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
    
    public IEnumerable<OrderedDeviceModel> GetAll(int userId)
    {
        return _repository.GetAll().Where(x=>x.UserId == userId);
    }

    public async Task Update(OrderedDeviceModel device)
    {
        await _repository.Update(device);
    }

    public async Task<bool> TryCreate(int userId)
    {
        var carts = _shoppingCartService.GetByUserId(userId);

        if (carts.Count == 0)
            return false;
        
        foreach (ShoppingCartModel shoppingCartModel in carts)
        {
            DeviceModel deviceModel = _deviceService.GetById(shoppingCartModel.DeviceId);
            var orderedDevice = _mapper.Map<OrderedDeviceModel>(deviceModel);
            orderedDevice.Count = _shoppingCartService.GetDeviceCountById(userId, deviceModel.Id);
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

    public async Task<bool> SetPurchased(int orderId)
    {
      OrderedDeviceModel? orderedDeviceModel =  _repository.GetAll().FirstOrDefault(x => x.Id == orderId);

      if (orderedDeviceModel == null)
          return false;
      
      orderedDeviceModel.IsPurchased = true;
      OrderedDeviceModel = orderedDeviceModel;
      await _repository.Update(orderedDeviceModel);
      await _unitOfWork.SaveChangesAsync();
      return true;
    }
}