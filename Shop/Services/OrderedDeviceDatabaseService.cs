using Shop.Data;
using Shop.Models;

namespace Shop.Services;

public class OrderedDeviceDatabaseService
{
    private readonly IRepository<OrderedDeviceModel> _repository;

    public OrderedDeviceModel OrderedDevice { get; set; }

    public OrderedDeviceDatabaseService(IRepository<OrderedDeviceModel> repository)
    {
        _repository = repository;
    }

    public IQueryable<OrderedDeviceModel> GetAll()
    {
        return _repository.GetAll();
    }
}