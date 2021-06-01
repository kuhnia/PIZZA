using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PIZZA.ViewModels
{
    public class UpdateDrinksModel
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
        public int Id { get; set; }
    }
}
