using Shop.Models;

namespace Shop.Data;

public class UserRepository : IRepository<UserModel>
{
    private readonly UserDbContext _userDbContext;

    public UserRepository(UserDbContext userDbContext)
    {
        _userDbContext = userDbContext;
    }

    public IQueryable<UserModel> GetAll()
    {
        return _userDbContext.Users;
    }

    public async Task Add(UserModel entity)
    {
        await _userDbContext.AddAsync(entity);
        await _userDbContext.SaveChangesAsync();
    }

    public async Task Remove(UserModel entity)
    {
        _userDbContext.Remove(entity);
        await _userDbContext.SaveChangesAsync();
    }

    public async Task Update(UserModel entity)
    {
        _userDbContext.Users.Update(entity);
        await _userDbContext.SaveChangesAsync();
    }
}