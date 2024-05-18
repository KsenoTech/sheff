using Microsoft.EntityFrameworkCore;
using WebSheff.ApplicationCore.DomModels;
using WebSheff.ApplicationCore.Interfaces.Repositories;
using WebSheff.Infrastructure.Extensions;

namespace WebSheff.Infrastructure.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private SheffContext _dbcontext;
        private readonly ILogger _logger;

        public UserRepository(SheffContext dbcontext, ILogger logger)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }

        public List<User> GetList()
        {
            try
            {
                var users = _dbcontext.Useras.ToList();
                _logger.LogExtension("Get Useras", users);

                return users;
            }
            catch
            {
                _logger.LogExtension("Couldn`t get Useras", "", LogLevel.Error);
                return null;
            }
        }

        public User GetItem(int Id)
        {
            try
            {
                var users = _dbcontext.Useras.Find(Id);

                if (users == null)
                {
                    throw new Exception();
                }

                _logger.LogExtension("Get User", users);

                return users;
            }
            catch
            {
                _logger.LogExtension("Couldn`t get User with Id", Id, LogLevel.Error);
                return null;
            }
        }

        public bool Create(User item)
        {
            try
            {
                _dbcontext.Useras.Add(item);
                _logger.LogExtension("Create User", item);
                return true;
            }
            catch
            {
                _logger.LogExtension("Couldn`t create User", item, LogLevel.Error);
                return false;
            }
        }

        public bool Update(User item)
        {
            try
            {
                if (item != null)
                {
                    _dbcontext.Entry(item).State = EntityState.Modified;
                    _logger.LogExtension("Update User", item);
                    return true;
                }
                throw new Exception();

            }
            catch
            {
                _logger.LogExtension("Couldn`t update User", item, LogLevel.Error);
                return false;
            }
        }

        /// <summary>
        /// А зачем удалять клиента?
        /// </summary>
        /// <param Айди="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            //return true;
            try
            {
                var userToRemove = _dbcontext.Useras.FirstOrDefault(c => c.Id == id);
                if (userToRemove != null)
                {
                    _dbcontext.Useras.Remove(userToRemove);
                    _logger.LogExtension("Delete User", userToRemove);
                    return true;
                }
                throw new Exception();
            }
            catch
            {
                _logger.LogExtension("Couldn`t delete User with id", id, LogLevel.Error);
                return false;
            }
        }
    }
}
