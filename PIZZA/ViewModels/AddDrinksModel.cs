using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace PIZZA.ViewModels
{
    public class AddDrinksModel
    {
        [Required(ErrorMessage = "Не вказано Назву")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Завантажте фото")]
        [DataType(DataType.Upload)]
        public IFormFile Img { get; set; }

        [Required(ErrorMessage = "Вкажіть ціну")]
        [DataType(DataType.Text)]
        public double Price { get; set; }

        [Required(ErrorMessage = "Виберіть категорію")]
        [DataType(DataType.Text)]
        public string Category { get; set; }
    }
}
