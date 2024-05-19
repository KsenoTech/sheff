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
            DateTime? dataTime,
            string? description,
            int? generalBudget,
            string? feedbackText,
            bool? isItFinished,
            bool? canIdoIt
            )
        {
            #region Проверка
            var clientnew = _clientservice.GetUser(client.Id);
            if (clientnew == null)
            {
                return null;
            }
            #endregion

            Smetum smeta = new Smetum()
            {
                IdClient = client.Id,
                Description = description,
                TimeOrder = dataTime,
                GeneralBudget = generalBudget,
                FeedbackText = feedbackText,
                IsItFinished = null,
                CanIdoIt = null
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
