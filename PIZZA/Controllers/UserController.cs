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

        [HttpGet]
        public async Task<IActionResult> EditPizza()
        {
            return View(new EditPizzaModel { Pizza = db.Pizza, Id = -1 });
        }

        [HttpGet]
        public async Task<IActionResult> PageEditPizza(string Id)
        {
            Pizza pizza = db.GetPizza(int.Parse(Id));
            return View(new UpdatePizzaModel {Name = pizza.Name, Category = pizza.Category, Description = pizza.Description, Price = pizza.Price, Weight = pizza.Weigth, Id = pizza.Id});
        }

        [HttpPost]
        public async Task<IActionResult> PageEditPizza(UpdatePizzaModel model)
        {
            byte[] imageData = null;
            // считываем переданный файл в массив байтов
            using (var binaryReader = new BinaryReader(model.Img.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)model.Img.Length);
            }
            db.Pizza.Remove(db.GetPizza(model.Id));
            db.Pizza.Add(new Pizza { Name = model.Name, Img = imageData, Description = model.Description, Price = model.Price, Category = model.Category, Weigth = model.Weight});
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> EditDrinks()
        {
            return View(new EditDrinksModel { Drinks = db.Drink, Id = -1 });
        }

        [HttpGet]
        public async Task<IActionResult> PageEditDrinks(string Id)
        {
            Drink drink = db.GetDrink(int.Parse(Id));
            return View(new UpdateDrinksModel { Name = drink.Name, Category = drink.Category, Price = drink.Price, Id = drink.Id });
        }

        [HttpPost]
        public async Task<IActionResult> PageEditDrinks(UpdateDrinksModel model)
        {
            byte[] imageData = null;
            // считываем переданный файл в массив байтов
            using (var binaryReader = new BinaryReader(model.Img.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)model.Img.Length);
            }
            db.Drink.Remove(db.GetDrink(model.Id));
            db.Drink.Add(new Drink { Name = model.Name, Img = imageData, Price = model.Price, Category = model.Category });
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> EditSushi()
        {
            return View(new EditSushiModel { Sushi = db.Sushi, Id = -1 });
        }

        [HttpGet]
        public async Task<IActionResult> PageEditSushi(string Id)
        {
            Sushi sushi = db.GetSushi(int.Parse(Id));
            return View(new UpdateSushiModel { Name = sushi.Name, Category = sushi.Category, Description = sushi.Description, Price = sushi.Price, Id = sushi.Id });
        }

        [HttpPost]
        public async Task<IActionResult> PageEditSushi(UpdateSushiModel model)
        {
            byte[] imageData = null;
            // считываем переданный файл в массив байтов
            using (var binaryReader = new BinaryReader(model.Img.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)model.Img.Length);
            }
            db.Sushi.Remove(db.GetSushi(model.Id));
            db.Sushi.Add(new Sushi { Name = model.Name, Img = imageData, Description = model.Description, Price = model.Price, Category = model.Category,});
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
