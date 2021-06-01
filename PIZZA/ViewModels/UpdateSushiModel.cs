using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PIZZA.ViewModels
{
    public class UpdateSushiModel
    {
        [Required(ErrorMessage = "Не вказано Назву")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Завантажте фото")]
        [DataType(DataType.Upload)]
        public IFormFile Img { get; set; }

        [Required(ErrorMessage = "Додайте опис")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Виберіть категорію")]
        [DataType(DataType.Text)]
        public string Category { get; set; }

        [Required(ErrorMessage = "Вкажіть ціну")]
        [DataType(DataType.Text)]
        public double Price { get; set; }

        public int Id { get; set; }
    }
}
