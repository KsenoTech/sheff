using WebSheff.ApplicationCore.DomModels;
using WebSheff.ApplicationCore.Interfaces.Repositories;

namespace WebSheff.Infrastructure.DAL.Repositories
{
    public class DbRepository : IDbRepository
    {
        private SheffContext _dbcontext;
        private readonly ILogger<SheffContext> _logger;

        private ProvidedServiceRepository _ourServiceRepository;
        private UsersRepository _usersRepository;

        public DbRepository (SheffContext dbcontext, ILogger<SheffContext> logger)
        {
            _dbcontext = dbcontext;
            _logger = logger;            
        }

        public IRepository<User> Users
        {
            get
            {
                if (_usersRepository == null)
                    _usersRepository = new UsersRepository(_dbcontext, _logger);
                return _usersRepository;
            }
        }

        public IRepository<ProvidedService> ProvidedServices
        {
            get
            {
                if (_ourServiceRepository == null)
                    _ourServiceRepository = new ProvidedServiceRepository(_dbcontext, _logger);
                return _ourServiceRepository;
            }
        }

        public IRepository<VidRabot> VidRabots
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IRepository<Smetum> Smetas
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Save()
        {
            throw new NotImplementedException();
        }
    }
}
