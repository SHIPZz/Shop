using Shop.Data;
using Shop.Models;

namespace Shop.Services;

public class OrderedDeviceDatabaseService
{
    private readonly UnitOfWork _unitOfWork;

    public OrderedDeviceModel OrderedDevice { get; set; }

    public OrderedDeviceDatabaseService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IQueryable<OrderedDeviceModel> GetAll()
    {
        return _unitOfWork.Resolve<BaseRepository<OrderedDeviceModel>, OrderedDeviceModel>().GetAll();
    }
}