using Microsoft.EntityFrameworkCore;
using PIZZA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIZZA.ViewModels
{
    public class EditSushiModel
    {
        public DbSet<Sushi> Sushi { get; set; }

        public int Id { get; set; }
    }
}
