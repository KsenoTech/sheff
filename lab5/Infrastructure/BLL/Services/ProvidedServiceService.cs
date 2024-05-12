using WebSheff.ApplicationCore.Interfaces.Repositories;
using WebSheff.ApplicationCore.Interfaces.Services;
using WebSheff.ApplicationCore.DomModels;

namespace WebSheff.Infrastructure.BLL.Services
{
    public class ProvidedServiceService : IProvidedServiceService
    {
        private IDbRepository db;

        public ProvidedServiceService(IDbRepository _db)
        {
            db = _db;
        }

        public bool CreateProvidedService(
            string newdescription, 
            string newtitle, 
            int newcost_of_m, 
            int newcost_of_m2)
        {
            var providedServiceCreated = db.ProvidedServices.Create(new ProvidedService()
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
            ProvidedService p = db.ProvidedServices.GetItem(id);
            if (p == null)
                return false;

            var psDeleted = db.ProvidedServices.Delete(p.Id);
            if (psDeleted)
            {
                Save();
                return true;
            }
            return false;
        }

        public List<ProvidedService> GetAllProvidedServices()
        {
            return db.ProvidedServices.GetList();
        }

        public ProvidedService GetProvidedService(int id)
        {
            return db.ProvidedServices.GetItem(id);
        }

        public bool UpdateProvidedService(ProvidedService pold)
        {
            ProvidedService phnew = db.ProvidedServices.GetItem(pold.Id);

            if (phnew != null)
            {
                phnew.Id = pold.Id;
                phnew.Description = pold.Description;
                phnew.Title = pold.Title;
                phnew.CostOfM = pold.CostOfM;
                phnew.CostOfM2 = pold.CostOfM2;

                if (db.ProvidedServices.Update(phnew))
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
            if (db.Save() > 0)
                return true;
            return false;
        }
    }
}
