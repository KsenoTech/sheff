using WebSheff.ApplicationCore.DomModels;

namespace WebSheff.ApplicationCore.Interfaces.Services
{
    /// <summary>
    /// UserService для добавления пользователя
    /// </summary>
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUser(int Id);
        bool CreateUser(
            string surname,
            string name,
            string middlename,
            string email,
            string password,
            string address,
            string telephone);
        bool UpdateUser(User p);
        bool DeleteUser(int id);
    }
}
