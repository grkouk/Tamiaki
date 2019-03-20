using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Tamiaki.Helpers;
using Tamiaki.Models;
using Xamarin.Forms;

namespace Tamiaki.DataAccess
{
   public  class DatabaseContext : DbContext 
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<CashRegCategory> CashRegCategories { get; set; }

        public DatabaseContext()
        {
            
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var dbPath = DependencyService.Get<IDbPath>().GetDbPath();
            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }
    }
}
