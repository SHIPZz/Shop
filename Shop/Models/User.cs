namespace Shop.Models;

public class User
{
    public User(Guid id, string name, string passwordHash, string email)
    {
        Id = id;
        Name = name;
        PasswordHash = passwordHash;
        Email = email;
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public string PasswordHash { get; set; }

    public string Email { get; set; }

    public static User Create(Guid id, string name, string passwordHash, string email)
    {
        return new User(id, name, passwordHash, email); 
    }
}