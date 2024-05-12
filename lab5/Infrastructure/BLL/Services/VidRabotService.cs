using WebSheff.ApplicationCore.Interfaces.Repositories;
using WebSheff.ApplicationCore.Interfaces.Services;
using WebSheff.ApplicationCore.DomModels;

namespace WebSheff.Infrastructure.BLL.Services
{
    public class VidRabotService : IVidRabotService
    {
        private IDbRepository db;
        public VidRabotService(IDbRepository dbRepos)
        {
            db = dbRepos;
        }

        public bool CreateVidRabot(
            int Id_executor, 
            int Type_of_Service)
        {
            throw new NotImplementedException();
        }

        public bool DeleteVidRabot(int id)
        {
            throw new NotImplementedException();
        }

        public List<VidRabot> GetAllVidRabot()
        {
            throw new NotImplementedException();
        }

        public VidRabot GetVidRabot(int Id_executor)
        {
            throw new NotImplementedException();
        }

        public bool UpdateVidRabot(VidRabot p)
        {
            throw new NotImplementedException();
        }
    }
}
