using Shop.Data;
using Shop.Models;

namespace Shop.Services;

public class OrderedDeviceDatabaseService
{
    private readonly UnitOfWork _unitOfWork;
    private readonly BaseRepository<OrderedDeviceModel> _repository;

    public OrderedDeviceModel OrderedDevice { get; set; }

    public OrderedDeviceDatabaseService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _repository = _unitOfWork.Resolve<BaseRepository<OrderedDeviceModel>, OrderedDeviceModel>();
    }

    public OrderedDeviceModel? Get(int id) =>
        GetAll().FirstOrDefault(x => x.Id == id);

    public IQueryable<OrderedDeviceModel?> GetAll()
    {
        return _repository.GetAll();
    }

    public async Task Update(OrderedDeviceModel device)
    {
        await _repository.Update(device);
    }
}