using Microsoft.EntityFrameworkCore;
using WebSheff.ApplicationCore.DomModels;
using WebSheff.ApplicationCore.Interfaces.Repositories;
using WebSheff.Infrastructure.Extensions;

namespace WebSheff.Infrastructure.DAL.Repositories
{
    public class SmetaRepository : IRepository<Smetum>
    {
        private SheffContext _dbcontext;
        private readonly ILogger _logger;

        public SmetaRepository(SheffContext dbcontext, ILogger logger)
        {
            _dbcontext = dbcontext;
            _logger = logger;
        }

        public bool Create(Smetum item)
        {
            try
            {
                _dbcontext.Smeta.Add(item);
                _logger.LogExtension("Create Smetum", item);
                return true;
            }
            catch
            {
                _logger.LogExtension("Couldn`t create Smetum", item, LogLevel.Error);
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var p = _dbcontext.Smeta.Find(id);
                if (p != null)
                {
                    _dbcontext.Smeta.Remove(p);
                    return true;
                }
                _logger.LogExtension("Delete Smeta", p);
                return false;
            }
            catch
            {
                _logger.LogExtension("Couldn`t delete Smeta with id", id, LogLevel.Error);
                return false;
            }
        }

        public Smetum GetItem(int id)
        {//проблема
            try
            {
                var smeta = _dbcontext.Smeta.Find(id);
                if (smeta != null)
                {
                    _logger.LogExtension("Get Smeta by ID: " + id, smeta);
                    return null;
                }
                else
                {
                    _logger.LogExtension("Smeta not found with ID: " + id, smeta);
                    return smeta;
                }
            }
            catch (Exception ex)
            {
                _logger.LogExtension("Error occurred while getting Smeta with ID: " + id, ex, LogLevel.Error);
                return null;
            }
        }

        public List<Smetum> GetList()
        {
            try
            {
                var orders = _dbcontext.Smeta.ToList();
                _logger.LogExtension("Get Smetas", orders);

                return orders;
            }
            catch
            {
                _logger.LogExtension("Couldn`t get Smetas", "", LogLevel.Error);
                return null;
            }
        }

        public bool Update(Smetum item)
        {
            try
            {
                if (item != null)
                {
                    _dbcontext.Entry(item).State = EntityState.Modified;
                    _logger.LogExtension("Update Smeta", item);
                    return true;
                }
                throw new Exception();
            }
            catch
            {
                _logger.LogExtension("Couldn`t update Smeta", item, LogLevel.Error);
                return false;
            }
        }
    }
}
