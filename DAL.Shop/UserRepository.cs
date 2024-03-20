using AutoMapper;
using Domain.Shop.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Shop;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public UserRepository(AppDbContext appDbContext, IMapper mapper)
    {
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    public async Task Add(User user)
    {
        var userEntity = _mapper.Map<UserEntity>(user);

        await _appDbContext.Users.AddAsync(userEntity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<User> GetByEmail(string email)
    {
        UserEntity userEntity = await _appDbContext.Users
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(u => u.Email == email)
                                ?? throw new Exception();

        return _mapper.Map<User>(userEntity);
    }
}

public interface IUserRepository
{
    
}