using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSheff.ApplicationCore.DomModels;

public partial class User : IdentityUser
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? MiddleName { get; set; }

    public string? EMail { get; set; }

    public string? Password { get; set; }

    //[NotMapped]
    //public string? PasswordConfirm { get; set; } = null!;

    public string? Address { get; set; }

    public int? KolvoZakazov { get; set; }

    public string? TelephoneNumber { get; set; }

    public double? Rating { get; set; }

    public string? UserLogin { get; set; }

    public virtual ICollection<ProvidedService> TypeOfServices { get; set; } = new List<ProvidedService>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    [NotMapped]
    public virtual ICollection<VidRabot> VidRabots { get; set; } = new List<VidRabot>();

    [NotMapped]
    public virtual ICollection<ProvidedService> ProvidedServices { get; set; } = new List<ProvidedService>();

    public User() { }
}
