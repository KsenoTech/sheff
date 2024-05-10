using WebSheff.ApplicationCore.Models;

namespace WebSheff.ApplicationCore.Interfaces.Services
{
    /// <summary>
    /// Service для админа - создать услугу компании
    /// </summary>
    public interface IProvidedServiceService
    {
        List<ProvidedService> GetAllProvidedServices();
        ProvidedService GetProvidedService(int id);
        
        bool CreateProvidedService(
            string Description,
            string Title,
            int cost_of_m,
            int cost_of_m2
            );
        bool UpdateProvidedService(ProvidedService p);
        bool DeleteProvidedService(int id);
    }
}
