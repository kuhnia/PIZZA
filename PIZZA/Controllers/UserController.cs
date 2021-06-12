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
using Microsoft.AspNetCore.Http;

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
            return View(new AccauntModel { Cast = Cast.FromJson(db.GetUser(User.Identity.Name).Cast), Id = -1 });
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
            return View(new RemovePizzaModel { Pizza = db.Pizza, Id = -1 });
        }

        public async Task<IActionResult> DeleteSushi()
        {
            return View(new RemoveSushiModel { Sushi = db.Sushi, Id = -1 });
        }

        public async Task<IActionResult> DeleteDrinks()
        {
            return View(new RemoveDrinksModel { Drinks = db.Drink, Id = -1 });
        }


        [HttpPost]
        public IActionResult DeletePizza(RemovePizzaModel model)
        {
            db.Pizza.Remove(db.Pizza.FirstOrDefault(p => p.Id == model.Id));
            db.SaveChanges();
            return View(new RemovePizzaModel { Pizza = db.Pizza, Id = -1 });
        }
        [HttpPost]
        public IActionResult DeleteSushi(RemoveSushiModel model)
        {
            db.Sushi.Remove(db.Sushi.FirstOrDefault(p => p.Id == model.Id));
            db.SaveChanges();
            return View(new RemoveSushiModel { Sushi = db.Sushi, Id = -1 });
        }
        [HttpPost]
        public IActionResult DeleteDrinks(RemoveDrinksModel model)
        {
            db.Drink.Remove(db.Drink.FirstOrDefault(p => p.Id == model.Id));
            db.SaveChanges();
            return View(new RemoveDrinksModel { Drinks = db.Drink, Id = -1 });
        }


        [HttpGet]
        public async Task<IActionResult> EditPizza()
        {
            return View(new EditPizzaModel { Pizza = db.Pizza, Id = -1 });
        }
        [HttpGet]
        public async Task<IActionResult> EditDrinks()
        {
            return View(new EditDrinksModel { Drinks = db.Drink, Id = -1 });
        }
        [HttpGet]
        public async Task<IActionResult> EditSushi()
        {
            return View(new EditSushiModel { Sushi = db.Sushi, Id = -1 });
        }

        [HttpGet]
        public async Task<IActionResult> PageEditPizza(string Id)
        {
            Pizza pizza = db.GetPizza(int.Parse(Id));
            return View(new UpdatePizzaModel {Name = pizza.Name, Category = pizza.Category, Description = pizza.Description, Price = pizza.Price, Weight = pizza.Weigth, Id = pizza.Id});
        }
        [HttpGet]
        public async Task<IActionResult> PageEditDrinks(string Id)
        {
            Drink drink = db.GetDrink(int.Parse(Id));
            return View(new UpdateDrinksModel { Name = drink.Name, Category = drink.Category, Price = drink.Price, Id = drink.Id });
        }
        [HttpGet]
        public async Task<IActionResult> PageEditSushi(string Id)
        {
            Sushi sushi = db.GetSushi(int.Parse(Id));
            return View(new UpdateSushiModel { Name = sushi.Name, Category = sushi.Category, Description = sushi.Description, Price = sushi.Price, Id = sushi.Id });
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
            db.Sushi.Add(new Sushi { Name = model.Name, Img = imageData, Description = model.Description, Price = model.Price, Category = model.Category});
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
