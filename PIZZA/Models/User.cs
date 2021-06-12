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

        public int? RoleId { get; set; }
        public Role Role { get; set; }

        public string Cast { set; get; }

        public Cast GetCast()
        {
            return Models.Cast.FromJson(Cast);
        }

        public void SetCast(Models.Cast cast)
        {
            Cast = cast.ToJson();
        }

        public bool IsAdmin()
        {
            if (this.RoleId == 1)
                return true;
            return false;
        }

        //public Cast Cast { get; set; }

    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }

}
