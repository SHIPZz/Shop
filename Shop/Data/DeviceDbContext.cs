using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Data;

public class DeviceDbContext : DbContext
{
    public DeviceDbContext(DbContextOptions<DeviceDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<DeviceModel> Devices { get; set; }
}