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

        [Required(ErrorMessage = "Не вказано номер телефону")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}