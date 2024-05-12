using WebSheff.ApplicationCore.DomModels;

namespace WebSheff.ApplicationCore.DomModels
{
    public class SmetaOrder
    {
        public int SmetaId { get; set; }  // Внешний ключ к таблице Smeta
        public Smetum Smeta { get; set; }  // Навигационное свойство к сущности Smeta
        public virtual ICollection<ProvidedService> ProvidedServices { get; set; }

        public int ProvidedServiceId { get; set; }  // Внешний ключ к таблице ProvidedService
        public ProvidedService ProvidedService { get; set; }  // Навигационное свойство к сущности ProvidedService
        public virtual ICollection<Smetum> Smetas { get; set; }
    }
}

