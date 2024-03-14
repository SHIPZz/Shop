using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<OrderedDeviceModel> OrderedDevices { get; set; }
    public DbSet<UserModel> Users { get; set; }
    public DbSet<DeviceModel> Devices { get; set; }
    
}