using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIZZA.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { set; get; }
        public string Password { set; get; }
        public string PhoneNumber { set; get; }

        public string Cast { set; get; }

        public Cast GetCast()
        {
            return Models.Cast.FromJson(Cast);
        }

        public void SetCast(Models.Cast cast)
        {
            Cast = cast.ToJson();
        }

        //public Cast Cast { get; set; }

    }
}
