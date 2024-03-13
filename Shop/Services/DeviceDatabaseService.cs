using Shop.Data;
using Shop.Models;

namespace Shop.Services;

public class DeviceDatabaseService
{
    private readonly IRepository<DeviceModel> _repository;

    public DeviceDatabaseService(IRepository<DeviceModel> repository)
    {
        _repository = repository;
    }

    public IQueryable<DeviceModel> GetAll()
    {
        return _repository.GetAll();
    }
}