using WebSheff.ApplicationCore.Interfaces.Repositories;
using WebSheff.ApplicationCore.Interfaces.Services;
using WebSheff.ApplicationCore.DomModels;

namespace WebSheff.Infrastructure.BLL.Services
{
    public class SmetaService : ISmetaService
    {
        private IDbRepository db;
        private IProvidedServiceService _providedservice;
        private IUserService _clientservice;
        private IUserService _executorservice;

        public SmetaService(IDbRepository dbRepos, IProvidedServiceService providedservice, IUserService client, IUserService executor)
        {
            db = dbRepos;
            _providedservice = providedservice;
        }

        List<Smetum> ISmetaService.GetAllSmetas()
        {
            return db.Smetas.GetList();
        }

        public Smetum GetSmeta(int id)
        {
            return db.Smetas.GetItem(id);
        }

        public Smetum MakeSmeta(
            User client, 
            User executor, 
            ProvidedService providedService, 
            DateTime dataTime)
        {
            #region Проверка
            var providedservicenew = _providedservice.GetProvidedService(providedService.Id);

            if (providedservicenew == null)
            {
                return null;
            }

            var executornew = _executorservice.GetUser(executor.Id);

            if (executornew == null)
            {
                return null;
            }

            var clientnew = _clientservice.GetUser(client.Id);

            if (clientnew == null)
            {
                return null;
            }
            #endregion

            Smetum smeta = new Smetum()
            {
                Client = client,
                Executor = executor,
                SmProvidedService = providedservicenew
            };

            var smetaCreated = db.Smetas.Create(smeta);
            if (smetaCreated)
            {
                executornew.ProvidedServices.Add(providedservicenew);
                clientnew.ProvidedServices.Add(providedservicenew);
               

                if (db.Save() > 0)
                {
                    return GetSmeta(smeta.Id);
                }
            }
            return null;
        }

    }
}
