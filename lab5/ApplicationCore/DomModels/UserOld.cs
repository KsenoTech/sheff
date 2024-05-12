//using Microsoft.AspNetCore.Identity;
//using System.ComponentModel.DataAnnotations.Schema;
//using WebSheff.ApplicationCore.DomModels;

//namespace WebSheff.ApplicationCore.DomModels;

//public partial class User : IdentityUser
//{
//    //public int Id { get; set; }

//    //public string? Surname { get; set; } = null!; //убрать ?

//    //public string? Name { get; set; } = null!; //убрать ?

//    //public string? MiddleName { get; set; } = null!; //убрать ?

//    //public string? EMail { get; set; } = null!; //убрать ?

//    //public string? Password { get; set; } = null!; //убрать ?

//    //[NotMapped]
//    //public string? PasswordConfirm { get; set; } = null!; //убрать ?

//    //public string? Address { get; set; } = null!; //убрать ?

//    //public int? KolvoZakazov { get; set; }

//    //public string? TelephoneNumber { get; set; } = null!; //убрать ?

//    //public double? Rating { get; set; }

//    //// Добавим свойство для обратной связи с классом VidRabot
//    //public virtual ICollection<VidRabot> VidRabots { get; set; } = new List<VidRabot>();

//    //public virtual ICollection<ProvidedService> ProvidedServices { get; set; } = new List<ProvidedService>();
//    //public User() { }

//    public string Id { get; set; } = null!;

//    public string? Surname { get; set; }

//    public string? Name { get; set; }

//    public string? MiddleName { get; set; }

//    public string? EMail { get; set; }

//    public string? Password { get; set; }

//    [NotMapped]
//    public string? PasswordConfirm { get; set; } = null!; //убрать ?

//    public string? Address { get; set; }

//    public int? KolvoZakazov { get; set; }

//    public string? TelephoneNumber { get; set; }

//    public double? Rating { get; set; }

//    public string? UserName { get; set; }

//    public string? NormalizedUserName { get; set; }

//    public string? NormalizedEmail { get; set; }

//    public bool EmailConfirmed { get; set; }

//    public string? PasswordHash { get; set; }

//    public string? SecurityStamp { get; set; }

//    public string? ConcurrencyStamp { get; set; }

//    public string? PhoneNumber { get; set; }

//    public bool PhoneNumberConfirmed { get; set; }

//    public bool TwoFactorEnabled { get; set; }

//    public DateTimeOffset? LockoutEnd { get; set; }

//    public bool LockoutEnabled { get; set; }

//    public int AccessFailedCount { get; set; }

//    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } = new List<AspNetUserClaim>();

//    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

//    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; } = new List<AspNetUserToken>();

//    public virtual ICollection<AspNetRole> Roles { get; set; } = new List<AspNetRole>();

//    public virtual ICollection<ProvidedService> TypeOfServices { get; set; } = new List<ProvidedService>();

//    public virtual ICollection<VidRabot> VidRabots { get; set; } = new List<VidRabot>();

//    public virtual ICollection<ProvidedService> ProvidedServices { get; set; } = new List<ProvidedService>();

//    public User() { }

//}
