namespace Application.Shop.Services;

public class UserService
{
    private readonly IPasswordHasherService _passwordHasher;

    public UserService(IPasswordHasherService passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public async Task Register(string name, string email, string password)
    {
        var hashedPassword = _passwordHasher.Generate(password);
    }
}