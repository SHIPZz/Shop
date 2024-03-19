using Shop.Data;
using Shop.Models;

namespace Shop.Services;

public class ShoppingCartDatabaseService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly BaseRepository<ShoppingCartModel> _repository;

    public ShoppingCartDatabaseService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _repository = _unitOfWork.Resolve<BaseRepository<ShoppingCartModel>, ShoppingCartModel>();
    }

    public async Task<bool> Remove(int deviceId, int userId)
    {
        var cart = _repository.GetAll().FirstOrDefault(x => x.DeviceId == deviceId && x.UserId == userId);

        if (cart == null)
        {
            return false;   
        }
        
        await _repository.Remove(cart);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public ShoppingCartModel? GetByUserId(int userId)
    {
        var repo = _unitOfWork.Resolve<BaseRepository<ShoppingCartModel>, ShoppingCartModel>();
        var cart = repo.GetAll().FirstOrDefault(x => x.UserId == userId);
        return cart;
    }

    public async Task<bool> Add(int deviceId, int userId)
    {
        var cart = _repository.GetAll().FirstOrDefault(x => x.DeviceId == deviceId && x.UserId == userId);

        if (cart == null)
        {
            return false;
        }
        
        await _repository.Add(cart);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}