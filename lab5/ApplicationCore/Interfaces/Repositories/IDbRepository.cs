using WebSheff.ApplicationCore.Models;

namespace WebSheff.ApplicationCore.Interfaces.Repositories
{
    public interface IDbRepository
    {
        IRepository<User> Users { get; }
        IRepository<ProvidedService> ProvidedServices { get;}
        IRepository<VidRabot> VidRabots { get;}
        IRepository<Smeta> Smetas { get; }
        int Save();
    }
}