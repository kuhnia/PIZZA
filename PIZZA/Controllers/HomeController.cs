using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PIZZA.Models;
using PIZZA.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PIZZA.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
        }
        
        public async Task<ActionResult> AddPizzaToCast(string num)
        {
            //Do Something
            User user = db.GetUser(User.Identity.Name);
            Cast cast = new Cast();
            if (user.Cast != null)
                cast= Cast.FromJson(user.Cast);
            cast.Pizza.Add(db.GetPizza(int.Parse(num)));
            user.Cast = cast.ToJson();
            await db.SaveChangesAsync();
            return View();
        }

        public async Task<ActionResult> AddDrinkToCast(string num)
        {
            //Do Something
            User user = db.GetUser(User.Identity.Name);
            Cast cast = new Cast();
            if (user.Cast != null)
                cast = Cast.FromJson(user.Cast);
            cast.Drink.Add(db.GetDrink(int.Parse(num)));
            user.Cast = cast.ToJson();
            await db.SaveChangesAsync();
            return View();
        }

        public async Task<ActionResult> AddSushiToCast(string num)
        {
            //Do Something
            User user = db.GetUser(User.Identity.Name);
            Cast cast = new Cast();
            if (user.Cast != null)
                cast = Cast.FromJson(user.Cast);
            cast.Sushi.Add(db.GetSushi(int.Parse(num)));
            user.Cast = cast.ToJson();
            await db.SaveChangesAsync();
            return View();
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Pizza.ToListAsync());
        }


        public async Task<IActionResult> PotablesAsync()
        {
            return View(await db.Drink.ToListAsync());
        }

        public async Task<IActionResult> SushiAsync()
        {
            return View(await db.Sushi.ToListAsync());
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {

                User user = await db.User.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Неправильні логін, або пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.User.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    db.User.Add(new User { Email = model.Email, Password = model.Password, PhoneNumber = model.PhoneNumber });
                    await db.SaveChangesAsync();

                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }


        public async Task RemovePizzaFromCastAsync(string Id)
        {
            //Do Something
            User user = db.GetUser(User.Identity.Name);
            Cast cast = new Cast();
            if (user.Cast != null)
                cast = Cast.FromJson(user.Cast);
            cast.Pizza.Remove(db.GetPizza(int.Parse(Id)));
            user.Cast = cast.ToJson();
            await db.SaveChangesAsync();
        }

        public async Task RemoveDrinkFromCastAsync(string Id)
        {
            //Do Something
            User user = db.GetUser(User.Identity.Name);
            Cast cast = new Cast();
            if (user.Cast != null)
                cast = Cast.FromJson(user.Cast);
            cast.Drink.Remove(db.GetDrink(int.Parse(Id)));
            user.Cast = cast.ToJson();
            await db.SaveChangesAsync();
        }

        public async Task RemoveSushiFromCastAsync(string Id)
        {
            //Do Something
            User user = db.GetUser(User.Identity.Name);
            Cast cast = new Cast();
            if (user.Cast != null)
                cast = Cast.FromJson(user.Cast);
            cast.Sushi.Remove(db.GetSushi(int.Parse(Id)));
            user.Cast = cast.ToJson();
            await db.SaveChangesAsync();
        }
    }
}
