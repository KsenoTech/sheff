namespace WebSheff.ApplicationCore.Models;

public partial class ProvidedService
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int? CostOfM { get; set; }

    public string Title { get; set; } = null!;

    public int? CostOfM2 { get; set; }

    public virtual ICollection<User> IdExecutors { get; set; } = new List<User>();

    public virtual ICollection<Smeta> IdSmeta { get; set; } = new List<Smeta>();
}
