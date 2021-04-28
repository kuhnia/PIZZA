using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIZZA
{
    public class AppContent : DbContext
    {
        public AppContent(DbContextOptions<AppContent> options) : base(options) { }

        public DbSet<>
    }
}
