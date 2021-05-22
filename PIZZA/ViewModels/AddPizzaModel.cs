using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIZZA.ViewModels
{
    public class AddPizzaModel
    {
        //[Required(ErrorMessage = "Не вказано E-mail")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Не вказано пароль")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
