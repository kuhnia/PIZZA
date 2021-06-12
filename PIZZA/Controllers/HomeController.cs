using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public async Task<ActionResult> AddPizzaToCast(string num)
        {

            //Do Something
            User user = db.GetUser(User.Identity.Name);
            Cast cast = new Cast();
            if (user.Cast != null)
                cast = Cast.FromJson(user.Cast);
            cast.Pizza.Add(db.GetPizza(int.Parse(num)));
            string str = cast.ToJson();
            user.Cast = str;
            db.User.Update(user);
            db.SaveChanges();
            return View();
        }

        [Authorize]
        public async Task<ActionResult> AddDrinkToCast(string num)
        {
            //Do Something
            User user = db.GetUser(User.Identity.Name);
            Cast cast = new Cast();
            if (user.Cast != null)
                cast = Cast.FromJson(user.Cast);
            cast.Drink.Add(db.GetDrink(int.Parse(num)));
            string str = cast.ToJson();
            user.Cast = str;
            db.User.Update(user);
            db.SaveChanges();
            return View();
        }

        [Authorize]
        public async Task<ActionResult> AddSushiToCast(string num)
        {
            //Do Something
            User user = db.GetUser(User.Identity.Name);
            Cast cast = new Cast();
            if (user.Cast != null)
                cast = Cast.FromJson(user.Cast);
            cast.Sushi.Add(db.GetSushi(int.Parse(num)));
            string str = cast.ToJson();
            user.Cast = str;
            db.User.Update(user);
            db.SaveChanges();
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
                User user = await db.User
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
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
                    // добавляем пользователя в бд
                    user = new User { Email = model.Email, Password = model.Password, PhoneNumber = model.PhoneNumber };
                    Role userRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == "user");
                    if (userRole != null)
                        user.Role = userRole;

                    db.User.Add(user);
                    await db.SaveChangesAsync();

                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [Authorize]
        public async Task<RedirectToActionResult> RemovePizzaFromCast(AccauntModel model)
        {
            //Do Something
            User user = db.GetUser(User.Identity.Name);
            Cast cast = new Cast();
            if (user.Cast != null)
                cast = Cast.FromJson(user.Cast);
            cast.Pizza.RemoveAll(r => r.Id == model.Id); ;
            db.GetUser(User.Identity.Name).Cast = cast.ToJson();
            await db.SaveChangesAsync();
            return RedirectToAction("Accaunt", "User");
        }
        [Authorize]
        public async Task<RedirectToActionResult> RemoveDrinkFromCast(AccauntModel model)
        {
            User user = db.GetUser(User.Identity.Name);
            Cast cast = new Cast();
            if (user.Cast != null)
                cast = Cast.FromJson(user.Cast);
            cast.Drink.RemoveAll(r => r.Id == model.Id); ;
            db.GetUser(User.Identity.Name).Cast = cast.ToJson();
            await db.SaveChangesAsync();
            return RedirectToAction("Accaunt", "User");
        }
        [Authorize]
        public async Task<RedirectToActionResult> RemoveSushiFromCast(AccauntModel model)
        {
            User user = db.GetUser(User.Identity.Name);
            Cast cast = new Cast();
            if (user.Cast != null)
                cast = Cast.FromJson(user.Cast);
            cast.Sushi.RemoveAll(r => r.Id == model.Id); ;
            db.GetUser(User.Identity.Name).Cast = cast.ToJson();
            await db.SaveChangesAsync();
            return RedirectToAction("Accaunt", "User");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Home");
        }
    }
}
