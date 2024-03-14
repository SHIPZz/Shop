using Shop.Data;
using Shop.Models;

namespace Shop.Services;

public class UserDatabaseService
{
    private readonly UnitOfWork _unitOfWork;

    public UserDatabaseService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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
            Email = userViewModel.Email
        };

        BaseRepository<UserModel> repository = _unitOfWork.Resolve<BaseRepository<UserModel>, UserModel>();
        await repository.Add(user);

        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public bool HasUser(string email)
    {
        BaseRepository<UserModel> repository = _unitOfWork.Resolve<BaseRepository<UserModel>, UserModel>();
        UserModel? user = repository.GetAll().FirstOrDefault(x => x.Email == email);

        return user != null;
    }
}