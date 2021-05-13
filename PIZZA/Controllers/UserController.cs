using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIZZA.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Accaunt()
        {
            return View();
        }
        public IActionResult AddPizza()
        {
            return View();
        }
        public IActionResult AddSushi()
        {
            return View();
        }

        public IActionResult AddDrinks()
        {
            return View();
        }
        public IActionResult DeletePizza()
        {
            return View();
        }

    }
}
