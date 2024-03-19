using Shop.Data;
using Shop.Models;

namespace Shop.Services;

public class OrderedDeviceDatabaseService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly BaseRepository<OrderedDeviceModel> _repository;
    private ShoppingCartDatabaseService _shoppingCartDatabaseService;

    public OrderedDeviceModel OrderedDevice { get; set; }

    public OrderedDeviceDatabaseService(UnitOfWork unitOfWork, ShoppingCartDatabaseService shoppingCartDatabaseService)
    {
        _shoppingCartDatabaseService = shoppingCartDatabaseService;
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

    public async Task<OrderedDeviceModel?> TryCreate(int userId)
    {
        var cart = _shoppingCartDatabaseService.GetByUserId(userId);

        if (cart == null)
            return null;

        var orderedModel = new OrderedDeviceModel()
        {
            UserId = cart.UserId,
        };

        await _repository.Add(orderedModel);
        await _unitOfWork.SaveChangesAsync();
        return orderedModel;
    }
}