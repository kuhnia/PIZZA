using Microsoft.AspNetCore.Mvc;
using PIZZA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIZZA.Models;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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

        [Authorize]
        public async Task<IActionResult> Accaunt()
        {
            return View(Cast.FromJson(db.GetUser(User.Identity.Name).Cast));
        }
        public IActionResult AddPizza()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPizza(AddPizzaModel model)
        {
            byte[] imageData = null;
            // считываем переданный файл в массив байтов
            using (var binaryReader = new BinaryReader(model.Img.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)model.Img.Length);
            }
            db.Pizza.Add(new Pizza { Name = model.Name, Img = imageData, Description = model.Description, Price = model.Price, Category = model.Category, Weigth = model.Weight });
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AddSushi()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSushi(AddSushiModel model)
        {
            byte[] imageData = null;
            // считываем переданный файл в массив байтов
            using (var binaryReader = new BinaryReader(model.Img.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)model.Img.Length);
            }
            db.Sushi.Add(new Sushi { Name = model.Name, Img = imageData, Description = model.Description, Price = model.Price, Category = model.Category});
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddDrinks()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDrink(AddDrinksModel model)
        {
            byte[] imageData = null;
            // считываем переданный файл в массив байтов
            using (var binaryReader = new BinaryReader(model.Img.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)model.Img.Length);
            }
            db.Drink.Add(new Drink { Name = model.Name, Img = imageData, Price = model.Price, Category = model.Category });
            await db.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DeletePizza()
        {
            return View(await db.Pizza.ToListAsync());
        }

        public async Task<IActionResult> DeleteSushi()
        {
            return View(await db.Sushi.ToListAsync());
        }

        public async Task<IActionResult> DeleteDrinks()
        {
            return View(await db.Drink.ToListAsync());
        }


        public async Task<IActionResult> EditPizza()
        {
            return View(await db.Pizza.ToListAsync());
        }
        public async Task<IActionResult> EditSushi()
        {
            return View(await db.Sushi.ToListAsync());
        }
        public async Task<IActionResult> EditDrinks()
        {
            return View(await db.Drink.ToListAsync());
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
