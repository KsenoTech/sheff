using System;
using System.Collections.Generic;

namespace WebSheff.Modells;

public partial class ProvidedService
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int? CostOfM { get; set; }

    public string Title { get; set; } = null!;

    public int? CostOfM2 { get; set; }

    public virtual ICollection<User> IdExecutors { get; set; } = new List<User>();

    public virtual ICollection<Smetum> IdSmeta { get; set; } = new List<Smetum>();
}
