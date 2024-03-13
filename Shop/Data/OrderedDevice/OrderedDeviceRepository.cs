using Shop.Models;

namespace Shop.Data.OrderedDevice;

public class OrderedDeviceRepository : IRepository<OrderedDeviceModel>
{
    private readonly OrderedDeviceDbContext _orderedDeviceDbContext;

    public OrderedDeviceRepository(OrderedDeviceDbContext orderedDeviceDbContext)
    {
        _orderedDeviceDbContext = orderedDeviceDbContext;
    }

    public IQueryable<OrderedDeviceModel> GetAll() => 
        _orderedDeviceDbContext.Devices;

    public async Task Add(OrderedDeviceModel entity)
    {
        await _orderedDeviceDbContext.AddAsync(entity);
        await _orderedDeviceDbContext.SaveChangesAsync();
    }

    public async Task Remove(OrderedDeviceModel entity)
    {
        _orderedDeviceDbContext.Remove(entity);
        await _orderedDeviceDbContext.SaveChangesAsync();
    }

    public async Task Update(OrderedDeviceModel entity)
    {
        _orderedDeviceDbContext.Devices.Update(entity);
        await _orderedDeviceDbContext.SaveChangesAsync();
    }
}