using System.ComponentModel.DataAnnotations;

namespace WebSheff.ApplicationCore.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }


        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
    }
}
