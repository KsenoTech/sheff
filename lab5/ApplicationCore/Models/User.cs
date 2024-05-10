using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSheff.ApplicationCore.Models;

public partial class User : IdentityUser
{
    public int Id { get; set; }

    public string? Surname { get; set; } = null!; //убрать ?

    public string? Name { get; set; } = null!; //убрать ?

    public string? MiddleName { get; set; } = null!; //убрать ?

    public string? Email { get; set; } = null!; //убрать ?

    public string? Password { get; set; } = null!; //убрать ?

    [NotMapped]
    public string? PasswordConfirm { get; set; } = null!; //убрать ?

    public string? Address { get; set; } = null!; //убрать ?

    public int? KolvoZakazov { get; set; }

    public string? TelephoneNumber { get; set; } = null!; //убрать ?

    public double? Rating { get; set; }

    public virtual ICollection<ProvidedService> ProvidedServices { get; set; } = new List<ProvidedService>();
}
