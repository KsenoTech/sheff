using WebSheff.ApplicationCore.Models;

namespace WebSheff.ApplicationCore.Interfaces.Services
{
    public interface ISmetaService
    {
        /// <summary>
        /// Создать заказ
        /// </summary>
        /// <returns></returns>
        Smeta MakeSmeta(           
           User client,
           User executor,
           ProvidedService providedService,
           DateTime dataTime
           );

        /// <summary>
        /// Получить все заказы
        /// </summary>
        /// <returns></returns>
        List<Smeta> GetAllSmetas();

        /// <summary>
        /// Получить смету
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Smeta GetSmeta(int id);
    }
}
