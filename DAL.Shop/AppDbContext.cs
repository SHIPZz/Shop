using Domain.Shop.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Shop;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<OrderedDeviceModel> OrderedDevices { get; set; }
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<DeviceModel> Devices { get; set; }
    public DbSet<ShoppingCartModel> ShoppingCart { get; set; }
    
}