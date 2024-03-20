using Shop.Data;
using Shop.Models;

namespace Shop.Services;

public class ShoppingCartDatabaseService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly BaseRepository<ShoppingCartModel> _repository;
    private ILogger<ICollection<DeviceModel>> _logger;

    public ShoppingCartDatabaseService(UnitOfWork unitOfWork, ILogger<ICollection<DeviceModel>> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _repository = _unitOfWork.Resolve<BaseRepository<ShoppingCartModel>, ShoppingCartModel>();
    }

    public async Task<bool> Remove(int deviceId, int userId, int count)
    {
        var carts = _repository
            .GetAll()
            .Where(x => x.UserId == userId && x.DeviceId == deviceId)
            .ToList();

        if (!carts.Any())
        {
            return false;
        }

        foreach (ShoppingCartModel shoppingCartModel in carts)
        {
            shoppingCartModel.DeviceCount -= count;

            if (shoppingCartModel.DeviceCount <= 0)
            {
                await _repository.Remove(shoppingCartModel);
                continue;
            }

            await _repository.Update(shoppingCartModel);
        }

        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public List<ShoppingCartModel>? GetByUserId(int userId)
    {
        return _repository.GetAll().Where(x => x.UserId == userId).ToList();
    }

    public int GetDeviceCountById(int userId, int deviceId)
    {
        return _repository.GetAll()
            .FirstOrDefault(x => x.UserId == userId && x.DeviceId == deviceId)
            .DeviceCount;
    }

    public async Task Add(int deviceId, int userId)
    {
        var carts = _repository
            .GetAll()
            .Where(x => x.UserId == userId && x.DeviceId == deviceId)
            .ToList();

        if (!carts.Any())
        {
            var cart = new ShoppingCartModel()
            {
                DeviceId = deviceId,
                UserId = userId,
                DeviceCount = 1,
            };

            await _repository.Add(cart);
            await _unitOfWork.SaveChangesAsync();
            return;
        }

        foreach (ShoppingCartModel shoppingCartModel in carts)
        {
            shoppingCartModel.DeviceCount++;
            await _repository.Update(shoppingCartModel);
        }
    }
}