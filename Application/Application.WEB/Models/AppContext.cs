using System.Data.Entity;

namespace Application.WEB.Models
{
    public class AppContext : DbContext
    {

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Dish> Dishes { get; set; }
    }
}