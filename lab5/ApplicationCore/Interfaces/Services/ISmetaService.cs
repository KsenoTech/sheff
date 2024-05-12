using WebSheff.ApplicationCore.DomModels;

namespace WebSheff.ApplicationCore.Interfaces.Services
{
    public interface ISmetaService
    {
        /// <summary>
        /// Создать заказ
        /// </summary>
        /// <returns></returns>
        Smetum MakeSmeta(           
           User client,
           User executor,
           ProvidedService providedService,
           DateTime dataTime
           );

        /// <summary>
        /// Получить все заказы
        /// </summary>
        /// <returns></returns>
        List<Smetum> GetAllSmetas();

        /// <summary>
        /// Получить смету
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Smetum GetSmeta(int id);
    }
}
