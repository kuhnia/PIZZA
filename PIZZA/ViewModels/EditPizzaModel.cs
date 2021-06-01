using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PIZZA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PIZZA.ViewModels
{
    public class EditPizzaModel
    {
        public DbSet<Pizza> Pizza { get; set; }

        public int Id { get; set; }
    }
}
