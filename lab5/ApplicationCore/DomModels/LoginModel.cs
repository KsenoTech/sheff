using System.ComponentModel.DataAnnotations;

namespace WebSheff.ApplicationCore.DomModels
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string UserLogin { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }


        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
    }
}
