using WebSheff.ApplicationCore.Interfaces.Repositories;
using WebSheff.ApplicationCore.Interfaces.Services;
using WebSheff.ApplicationCore.Models;

namespace WebSheff.Infrastructure.BLL.Services
{
    public class UserService : IUserService
    {
        private IDbRepository db;

        public UserService(IDbRepository dbRepos)
        {
            db = dbRepos;
        }

        public List<User> GetAllUsers()
        {
            return db.Users.GetList().ToList();
        }
        public User GetUser(int Id)
        {
            return db.Users.GetItem(Id);
        }

        public bool CreateUser(
            string surname,
            string name,
            string middlename,
            string email,
            string password,
            string address,
            string telephone)
        {
            var employeeCreated = db.Users.Create(new User()
            {
                Name = name,
                Surname = surname,
                MiddleName = middlename,
                Email = email,
                Password = password,
                PasswordConfirm = password,
                Address = address,
                TelephoneNumber = telephone,
                ProvidedServices = new List<ProvidedService>(),
            }); ;

            if (employeeCreated)
            {
                Save();
                return true;
            }
            return false;
        }

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }

          bool IUserService.UpdateUser(User p)
        {
            throw new NotImplementedException();
        }
    }
}
