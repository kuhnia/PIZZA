using Microsoft.EntityFrameworkCore;
using PIZZA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIZZA
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        //public DbSet<Order> Order { set; get; }
        public DbSet<Pizza> Pizza { set; get; }
        public DbSet<Drink> Drink { set; get; }
        public DbSet<Sushi> Sushi { set; get; }
        public DbSet<User> User { set; get; }

        public DbSet<Role> Roles { get; set; }

        public User GetUser(string email) => User.FirstOrDefault(c => c.Email == email);
        public Pizza GetPizza(int id) => Pizza.FirstOrDefault(c => c.Id == id);
        public Drink GetDrink(int id) => Drink.FirstOrDefault(c => c.Id == id);
        public Sushi GetSushi(int id) => Sushi.FirstOrDefault(c => c.Id == id);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };
            User adminUser = new User { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id, PhoneNumber = "0" };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }

    }
}
