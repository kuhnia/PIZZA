﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIZZA.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } // имя пользователя
        public int Age { get; set; } // возраст пользователя
        public string Email { set; get; }
        public string Password { set; get; }

    }
}
