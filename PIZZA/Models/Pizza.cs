using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIZZA.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Img { get; set; }
        public double Weigth { get; set; }
        public double Price { get; set; }

    }
}
