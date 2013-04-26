using  Wings.Core.Model;

namespace  Wings.Core.Service
{
    public interface IUserService : ICrudService<User>
    {
        bool IsUnique(string login);
        void ChangePassword(int id, string password);
        User Get(string Login, string password);
    }
}