using Shop.Data;
using Shop.Models;

namespace Shop.Services;

public class DeviceDatabaseService
{
    private readonly UnitOfWork _unitOfWork;

    public DeviceDatabaseService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IQueryable<DeviceModel> GetAll()
    {
        return _unitOfWork.Resolve<BaseRepository<DeviceModel>, DeviceModel>().GetAll();
    }
}