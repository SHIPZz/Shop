using Shop.Models;

namespace Shop.Data;

public class DeviceRepository : IRepository<DeviceModel>
{
    private readonly DeviceDbContext _deviceDbContext;

    public DeviceRepository(DeviceDbContext deviceDbContext)
    {
        _deviceDbContext = deviceDbContext;
    }

    public IQueryable<DeviceModel> GetAll()
    {
        return _deviceDbContext.Devices;
    }

    public async Task Add(DeviceModel entity)
    {
        await _deviceDbContext.AddAsync(entity);
        await _deviceDbContext.SaveChangesAsync();
    }

    public async Task Remove(DeviceModel entity)
    {
        _deviceDbContext.Remove(entity);
        await _deviceDbContext.SaveChangesAsync();
    }

    public async Task Update(DeviceModel entity)
    {
        _deviceDbContext.Devices.Update(entity);
        await _deviceDbContext.SaveChangesAsync();
    }
}