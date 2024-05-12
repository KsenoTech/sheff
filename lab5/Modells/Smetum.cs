using System;
using System.Collections.Generic;

namespace WebSheff.Modells;

public partial class Smetum
{
    public int Id { get; set; }

    public string? IdExecutor { get; set; }

    public string? Description { get; set; }

    public DateTime? TimeOrder { get; set; }

    public int? GeneralBudget { get; set; }

    public string? FeedbackText { get; set; }

    public bool? IsItFinished { get; set; }

    public bool? CanIdoIt { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProvidedService> IdProvidedServices { get; set; } = new List<ProvidedService>();
}
