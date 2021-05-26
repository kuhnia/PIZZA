using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIZZA.Models
{
    public class Sushi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Img { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }

    }
}
