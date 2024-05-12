namespace WebSheff.ApplicationCore.DomModels;

public partial class VidRabot
{
    public int Id_executor { get; set; }
    public int Type_of_Service { get; set; }

    // Добавим свойство Executor
    public virtual User Executor { get; set; }
    public virtual ICollection<User> IdExecutors { get; set; } = new List<User>();

    public virtual ICollection<Smetum> IdSmeta { get; set; } = new List<Smetum>();
}
