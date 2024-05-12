namespace WebSheff.ApplicationCore.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetList();
        T GetItem(int id);
        bool Create(T item);
        bool Update(T item);
        bool Delete(int id);
        T GetItem(string id);
        bool Delete(string id);
    }
}
