using Shop.Data;
using Shop.Models;

namespace Shop.Services;

public class DeviceDatabaseService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly BaseRepository<DeviceModel> _repository;

    public DeviceDatabaseService(UnitOfWork unitOfWork)
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