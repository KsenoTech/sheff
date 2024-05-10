namespace WebSheff.ApplicationCore.Models;

public class Smeta
{
    public int Id { get; set; }

    public int IdExecutor { get; set; }

    public int IdClient { get; set; }

    public string Description { get; set; } = null!;

    public DateTime TimeOrder { get; set; }

    public int GeneralBudget { get; set; }

    public string FeedbackText { get; set; } = null!;

    public bool IsItFinished { get; set; }

    public bool CanIdoIt { get; set; }

    public virtual ICollection<ProvidedService> IdProvededServices { get; set; } = new List<ProvidedService>();
    
    public Smeta() { }
    /// <summary>
    ///Позиция: Отклонен, Принят, В прогрессе, Закончен
    /// </summary>
    public enum Position
    {
        Rejected,
        Applied,
        InProgress,
        Finished
    }
}
