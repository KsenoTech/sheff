using WebSheff.ApplicationCore.Interfaces.Repositories;
using WebSheff.ApplicationCore.Interfaces.Services;
using WebSheff.ApplicationCore.DomModels;
using WebSheff.Controllers;

namespace WebSheff.Infrastructure.BLL.Services
{
    public class ProvidedServiceService : IProvidedServiceService
    {
        private IDbRepository _db;
        private readonly ILogger<AccountController> _logger;

        public ProvidedServiceService(IDbRepository data, ILogger<AccountController> logger)
        {
            _db = data;
            _logger = logger;
        }

        public bool CreateProvidedService(
            string newdescription, 
            string newtitle, 
            int newcost_of_m, 
            int newcost_of_m2)
        {
            var providedServiceCreated = _db.ProvidedServices.Create(new ProvidedService()
            {
                Description = newdescription,
                Title = newtitle,
                CostOfM = newcost_of_m,
                CostOfM2 = newcost_of_m2
            });
            if (providedServiceCreated)
            {
                Save();
                return true;
            }
            return false;
        }

        public bool DeleteProvidedService(int id)
        {
            ProvidedService p = _db.ProvidedServices.GetItem(id);
            if (p == null)
                return false;

            var psDeleted = _db.ProvidedServices.Delete(p.Id);
            if (psDeleted)
            {
                Save();
                return true;
            }
            return false;
        }

        public List<ProvidedService> GetAllProvidedServices()
        {
            return _db.ProvidedServices.GetList();
        }

        public ProvidedService GetProvidedService(int id)
        {
            return _db.ProvidedServices.GetItem(id);
        }

        public bool UpdateProvidedService(ProvidedService pold)
        {
            ProvidedService phnew = _db.ProvidedServices.GetItem(pold.Id);

            if (phnew != null)
            {
                phnew.Id = pold.Id;
                phnew.Description = pold.Description;
                phnew.Title = pold.Title;
                phnew.CostOfM = pold.CostOfM;
                phnew.CostOfM2 = pold.CostOfM2;

                if (_db.ProvidedServices.Update(phnew))
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
            if (_db.Save() > 0)
                return true;
            return false;
        }
    }
}
