namespace WebSheff.ApplicationCore.Models;

public partial class VidRabot
{
    public int Id_executor { get; set; }
    public int Type_of_Service { get; set; }

    public virtual ICollection<User> IdExecutors { get; set; } = new List<User>();

    public virtual ICollection<Smeta> IdSmeta { get; set; } = new List<Smeta>();
}
