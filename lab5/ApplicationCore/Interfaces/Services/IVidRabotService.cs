using WebSheff.ApplicationCore.Models;

namespace WebSheff.ApplicationCore.Interfaces.Services;

/// <summary>
/// Service для исполнителя - добавляет и набирает свои конкретные услуги
/// </summary>
public interface IVidRabotService
{
    List<VidRabot> GetAllVidRabot();
    VidRabot GetVidRabot(int Id_executor);

    bool CreateVidRabot(
        int Id_executor,
        int Type_of_Service
        );
    bool UpdateVidRabot(VidRabot p);
    bool DeleteProvidedService(int id);

}
