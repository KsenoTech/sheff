using Microsoft.EntityFrameworkCore;
using WebSheff.ApplicationCore.DomModels;
using WebSheff.ApplicationCore.Interfaces.Repositories;
using WebSheff.Infrastructure.Extensions;

namespace WebSheff.Infrastructure.DAL.Repositories
{
    public class ProvidedServiceRepository : IRepository<ProvidedService>
    {
        private SheffContext _dbcontext;
        private readonly ILogger _logger;

        public ProvidedServiceRepository(SheffContext db, ILogger logger)
        {
            _dbcontext = db;
            _logger = logger;
        }

        public bool Create(ProvidedService item)
        {
            try
            {
                _dbcontext.ProvidedServices.Add(item);
                _logger.LogExtension("Create OurService", item);
                return true;
            }
            catch
            {
                _logger.LogExtension("Couldn`t create OurService", item, LogLevel.Error);
                return false;
            }
        }

        public bool Delete(int id)
        {
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

        public ProvidedService GetItem(int Id)
        {
            try
            {
                var ourService = _dbcontext.ProvidedServices.Find(Id);

                if (ourService == null)
                {
                    throw new Exception();
                }

                _logger.LogExtension("Get OurService", ourService);

                return ourService;
            }
            catch
            {
                _logger.LogExtension("Couldn`t get OurService with Id", Id, LogLevel.Error);
                return null;
            }
        }

        public List<ProvidedService> GetList()
        {
            throw new NotImplementedException();
        }

        public bool Update(ProvidedService item)
        {
            try
            {
                if (item != null)
                {
                    _dbcontext.Entry(item).State = EntityState.Modified;
                    _logger.LogExtension("Update OurService", item);
                    return true;
                }
                throw new Exception();
            }
            catch
            {
                _logger.LogExtension("Couldn`t update OurService", item, LogLevel.Error);
                return false;
            }
        }
    }
}
