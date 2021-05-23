using Microsoft.AspNetCore.Mvc;
using PIZZA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIZZA.Models;
using System.Text;

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

        [HttpPost]
        public async Task<IActionResult> AddPizza(AddPizzaModel model)
        {
                db.Pizza.Add(new Pizza { Name = model.Name, Img = Encoding.ASCII.GetBytes(model.Img), Description = model.Description, Price = model.Price, Category = model.Category, Weigth = model.Weight });
                    await db.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
            return View(model);
        }
        public IActionResult AddSushi()
        {
            return View();
        }

        public IActionResult AddDrinks()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDrinks(AddDrinksModel model)
        {
            db.Drink.Add(new Drink { Name = model.Name, Img = model.Img, Price = model.Price, Category = model.Category});
            await db.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
            return View(model);
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
        public IActionResult PizzaDesigner()
        {
            return View();
        }

        public IActionResult PageEditPizza()
        {
            return View();
        }

        public IActionResult PageEditSushi()
        {
            return View();
        }

        public IActionResult PageEditDrinks()
        {
            return View();
        }
    }
}
