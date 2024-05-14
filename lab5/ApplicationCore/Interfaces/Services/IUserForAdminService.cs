using WebSheff.ApplicationCore.DomModels;

namespace WebSheff.ApplicationCore.Interfaces.Services
{
    /// <summary>
    /// UserService для Админа
    /// </summary>
    public interface IUserForAdminService
    {
        List<User> GetAllUsers();
        User GetUser(int Id);
        bool CreateClient(
            string surname,
            string name,
            string middlename,
            string email,
            string userLogin,
            string password,
            string address,
            string telephone
            );
        bool CreateExecutor(
            string surname,
            string name,
            string middlename,
            string email,
            string password,
            string userLogin,
            string address,
            string telephone,
            int kolvoZakazov,
            int rating
            );
        bool UpdateUser(User p);
        bool DeleteUser(int id);
    }
}
