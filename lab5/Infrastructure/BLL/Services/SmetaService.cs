using WebSheff.ApplicationCore.Interfaces.Repositories;
using WebSheff.ApplicationCore.Interfaces.Services;
using WebSheff.ApplicationCore.Models;

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

        List<Smeta> ISmetaService.GetAllSmetas()
        {
            throw new NotImplementedException();
        }

        public Smeta GetSmeta(int id)
        {
            throw new NotImplementedException();
        }

        public Smeta MakeSmeta(User client, User executor, ProvidedService providedService, DateTime dataTime)
        {
            //throw new NotImplementedException();

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

            Smeta smeta = new Smeta()
            {
                Client = client,  

            };
        }


    }
}
