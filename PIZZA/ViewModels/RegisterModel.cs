using System.ComponentModel.DataAnnotations;

namespace PIZZA.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не вказано E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не вказано пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Неправильний пароль")]
        public string ConfirmPassword { get; set; }
    }
}