namespace Application.Shop.Services;

public interface IPasswordHasherService
{
    string Generate(string password);
    bool Verify(string password, string hashedPassword);
}

public class PasswordHasherService : IPasswordHasherService
{
    public string Generate(string password) =>
        BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Verify(string password, string hashedPassword) =>
        BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);

}