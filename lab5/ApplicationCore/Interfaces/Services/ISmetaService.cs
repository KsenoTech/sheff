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
           int Idclient,
           
           string? description,
           int? generalBudget
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
        void MakeSmeta(string? idClient, string? description, int? generalBudget);
    }
}
