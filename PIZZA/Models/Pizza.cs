using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace PIZZA.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public byte[] Img { get; set; }
        public double Weigth { get; set; }
        public double Price { get; set; }

        public void AddToCast(ApplicationContext db)
        {
            //db.Cast.Add(new Cast(UserId = User.Identity.))
        }

    }
}
