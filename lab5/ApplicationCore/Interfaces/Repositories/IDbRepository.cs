using WebSheff.ApplicationCore.DomModels;

namespace WebSheff.ApplicationCore.Interfaces.Repositories
{
    public interface IDbRepository
    {
        IRepository<User> Users { get; }
        IRepository<ProvidedService> ProvidedServices { get;}
        IRepository<VidRabot> VidRabots { get;}
        IRepository<Smetum> Smetas { get; }
        int Save();
    }
}