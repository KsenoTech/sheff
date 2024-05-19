using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSheff.ApplicationCore.DomModels;

public partial class Smetum
{
    public int Id { get; set; }

    public int? IdClient { get; set; }

    public string? Description { get; set; }

    public DateTime? TimeOrder { get; set; }

    public int? GeneralBudget { get; set; }

    public string? FeedbackText { get; set; }

    public bool? IsItFinished { get; set; }

    public bool? CanIdoIt { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProvidedService> IdProvidedServices { get; set; } = new List<ProvidedService>();
    [NotMapped]
    public User Executor { get; set; }
    [NotMapped]
    public User Client { get; set; }
    [NotMapped]
    public ProvidedService SmProvidedService { get; set; }

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
