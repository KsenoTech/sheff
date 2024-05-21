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
            string? Idсlient,
            
            string? description,
            int? generalBudget
            )
        {
            #region Проверка
            var clientnew = _clientservice.GetUser(Idсlient);
            if (clientnew == null)
            {
                return null;
            }
            #endregion

            Smetum smeta = new Smetum()
            {
                IdClient = Idсlient,
                Description = description,
                GeneralBudget = generalBudget
            };

            var smetaCreated = db.Smetas.Create(smeta);
            if (smetaCreated)
            {
                
                if (db.Save() > 0)
                {
                    return GetSmeta(smeta.Id);
                }
            }
            return null;
        }

    }
}
