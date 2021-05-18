using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIZZA.Controllers
{
    public class UserController : Controller
    {
        private ApplicationContext db;
        public UserController(ApplicationContext context)
        {
            db = context;
        }

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
        public IActionResult DeleteSushi()
        {
            return View();
        }
        
        public IActionResult DeleteDrinks()
        {
            return View();
        }

        public IActionResult EditPizza()
        {
            return View();
        }
        public IActionResult EditSushi()
        {
            return View();
        }
        public IActionResult EditDrinks()
        {
            return View();
        }
    }
}
