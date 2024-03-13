using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Data.OrderedDevice;

public class OrderedDeviceDbContext : DbContext
{
    public OrderedDeviceDbContext(DbContextOptions<OrderedDeviceDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<OrderedDeviceModel> Devices { get; set; }
}