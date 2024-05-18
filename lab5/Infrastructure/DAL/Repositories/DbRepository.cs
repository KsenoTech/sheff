using WebSheff.ApplicationCore.DomModels;
using WebSheff.ApplicationCore.Interfaces.Repositories;

namespace WebSheff.Infrastructure.DAL.Repositories
{
    public class DbRepository : IDbRepository
    {
        private SheffContext _dbcontext;
        private readonly ILogger<SheffContext> _logger;

        private ProvidedServiceRepository _ourServiceRepository;
        private UserRepository _usersRepository;
        private SmetaRepository _smetaRepository;

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
                    _usersRepository = new UserRepository(_dbcontext, _logger);
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
                if (_smetaRepository == null)
                    _smetaRepository = new SmetaRepository(_dbcontext, _logger);
                return _smetaRepository;
            }
        }

        public int Save()
        {
            return _dbcontext.SaveChanges();
        }
    }
}
