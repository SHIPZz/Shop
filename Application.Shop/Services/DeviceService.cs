using DAL.Shop;
using Domain.Shop.Entity;
using Shop.Services;

namespace Application.Shop.Services;

public class DeviceService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly BaseRepository<DeviceModel> _repository;

    public DeviceService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _repository = _unitOfWork.Resolve<BaseRepository<DeviceModel>, DeviceModel>();
    }

    public DeviceModel GetById(int id) =>
        _repository.GetAll().FirstOrDefault(x => x.Id == id);

    public List<DeviceModel> GetAll()
    {
        return _repository.GetAll().ToList();
    }

    public async Task Add(DeviceModel deviceModel)
    {
        await _repository.Add(deviceModel);
    }
}