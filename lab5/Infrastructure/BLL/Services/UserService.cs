using WebSheff.ApplicationCore.Interfaces.Repositories;
using WebSheff.ApplicationCore.Interfaces.Services;
using WebSheff.ApplicationCore.DomModels;

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
        public User GetUser(string Id)
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
                EMail = email,
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

        public bool UpdateUser(User p)
        {
            User ph = db.Users.GetItem(p.Id);

            if (ph != null)
            {
                ph.Id = p.Id;
                ph.Name = p.Name;
                ph.Surname = p.Surname;
                ph.MiddleName = p.MiddleName;
                ph.Password = p.Password;
                ph.PasswordConfirm = p.PasswordConfirm;
                ph.Address = p.Address;
                ph.EMail = p.EMail;
                ph.TelephoneNumber = p.TelephoneNumber;
 
                if (db.Users.Update(ph))
                {
                    Save();
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool DeleteUser(string id)
        {
            User p = db.Users.GetItem(id);
            if (p != null)
            {
                var userDelete = db.Users.Delete(p.Id);

                if (userDelete)
                {
                    Save();
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
