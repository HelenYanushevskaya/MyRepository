using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;


namespace WebApp.Models
{
    public class AppContext : DbContext
    {

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Dish> Dishes { get; set; }
    }
}