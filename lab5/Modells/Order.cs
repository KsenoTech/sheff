using System;
using System.Collections.Generic;

namespace WebSheff.Modells;

public partial class Order
{
    public int Id { get; set; }

    public int IdSmeta { get; set; }

    public string IdClient { get; set; } = null!;

    public virtual User IdClientNavigation { get; set; } = null!;

    public virtual Smetum IdSmetaNavigation { get; set; } = null!;
}
