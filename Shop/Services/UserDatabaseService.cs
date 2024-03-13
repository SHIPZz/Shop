using Shop.Data;
using Shop.Models;

namespace Shop.Services;

public class UserDatabaseService
{
    private readonly IRepository<UserModel> _repository;

    public UserDatabaseService(IRepository<UserModel> repository)
    {
        _repository = repository;
    }

    public async Task<bool> TryCreate(UserViewModel userViewModel)
    {
        if (string.IsNullOrEmpty(userViewModel.Password) || string.IsNullOrEmpty(userViewModel.Username))
            return false;

        if (userViewModel.Birthday.Year < 1960f)
            return false;

        var user = new UserModel()
        {
            Username = userViewModel.Username,
            Password = userViewModel.Password,
            Birthday = userViewModel.Birthday,
        };

        await _repository.Add(user);
        return true;
    }

    public bool HasUser(string name)
    {
        UserModel? user = _repository.GetAll().FirstOrDefault(x => x.Username == name);

        return user != null;
    }
}