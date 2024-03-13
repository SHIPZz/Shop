using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Data;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<UserModel> Users { get; set; }
}