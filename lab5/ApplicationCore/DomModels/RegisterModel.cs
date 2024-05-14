using System.ComponentModel.DataAnnotations;

namespace WebSheff.ApplicationCore.DomModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Поле 'Фамилия' обязательно для заполнения")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }



        [Required(ErrorMessage = "Поле 'Имя' обязательно для заполнения")]
        [Display(Name = "Имя")]
        public string Name { get; set; }



        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }



        [Required(ErrorMessage = "Поле 'Email' обязательно для заполнения")]
        [EmailAddress(ErrorMessage = "Некорректный формат Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Поле 'Логин' обязательно для заполнения")]
        [Display(Name = "Логин")]
        public string UserLogin { get; set; }



        [Required(ErrorMessage = "Поле 'Пароль' обязательно для заполнения")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Пароль должен быть не менее {2} и не более {1} символов в длину", MinimumLength = 6)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }



        //[DataType(DataType.Password)]
        //[Display(Name = "Подтвердить пароль")]
        //[Compare("Password", ErrorMessage = "Пароли не совпадают")]
        //public string PasswordConfirm { get; set; }



        [Required(ErrorMessage = "Поле 'Адрес' обязательно для заполнения")]
        [Display(Name = "Адрес")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Поле 'Телефон' обязательно для заполнения")]
        [Phone(ErrorMessage = "Некорректный формат номера телефона")]
        [Display(Name = "Телефон")]
        public string TelephoneNumber { get; set; }

    }

}
