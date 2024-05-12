using System;
using System.Collections.Generic;

namespace WebSheff.Modells;

public partial class Smeta
{
    public int Id { get; set; }

    public int? IdExecutor { get; set; }

    public int? IdClient { get; set; }

    public string? Description { get; set; }

    public DateTime? TimeOrder { get; set; }

    public int? GeneralBudget { get; set; }

    public string? FeedbackText { get; set; }

    public bool? IsItFinished { get; set; }

    public bool? CanIdoIt { get; set; }

    public virtual ICollection<ProvidedService> IdProvededServices { get; set; } = new List<ProvidedService>();
}
