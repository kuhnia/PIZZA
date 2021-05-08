using System.ComponentModel.DataAnnotations;

namespace PIZZA.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Не вказано E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не вказано пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}