using Microsoft.EntityFrameworkCore;
using PIZZA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIZZA
{
    public class AppContent : DbContext
    {
        public AppContent(DbContextOptions<AppContent> options) : base(options) { }

        public DbSet<Cast> Cast { set; get; }
        public DbSet<Deserts> Deserts { set; get; }
        public DbSet<DietFood> DietFoods { set; get; }
        public DbSet<Order> Order { set; get; }
        public DbSet<Pizza> Pizza { set; get; }
        public DbSet<Rolls> Rolls { set; get; }
        public DbSet<Sauces> Sauces { set; get; }
        public DbSet<User> User { set; get; }

    }
}
