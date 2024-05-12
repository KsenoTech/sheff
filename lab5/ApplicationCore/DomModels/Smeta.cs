//using System.ComponentModel.DataAnnotations.Schema;

//namespace WebSheff.ApplicationCore.DomModels;

//public class Smeta
//{
//    public int Id { get; set; }

//    public int IdExecutor { get; set; }

//    public int IdClient { get; set; }

//    public string? Description { get; set; }

//    public DateTime TimeOrder { get; set; }

//    public int GeneralBudget { get; set; }

//    public string? FeedbackText { get; set; }

//    public bool IsItFinished { get; set; }

//    public bool CanIdoIt { get; set; }

//    public User Executor { get; set; }

//    public User Client { get; set; }

//    public ProvidedService ProvidedService { get; set; }

//    [NotMapped]
//    public virtual ICollection<ProvidedService> ProvidedServices { get; set; } = new List<ProvidedService>();


//    //public Smeta() { }

//    /// <summary>
//    ///Позиция: Отклонен, Принят, В прогрессе, Закончен
//    /// </summary>
//    public enum Position
//    {
//        Rejected,
//        Applied,
//        InProgress,
//        Finished
//    }
//}
