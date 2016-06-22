using Application.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;


namespace Application.DAL.Models
{
    public class AppContext : DbContext
    {
        public AppContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.SetInitializer<AppContext>(new StoreDbInitializer())
        }

        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<AppContext>
        {
            protected override void Seed(AppContext db)
            {
                db.Dishes.Add(new Dish { Name = "Курица «Пикассо»",Ingredients = "Курица Сладкий перец Соль Черный перец", Weight = 220 });
                db.Dishes.Add(new Dish { Name = "Азу по‑татарски", Ingredients = "Говядина Лук сооленые огурцы Соль Черный перец", Weight = 220 });
                db.Organizations.Add(new Organization { Name = "Сити-Фуд", Address = "ул.Пономаренко, 35а", Phone = 80292566745, Email = null });
                db.Organizations.Add(new Organization { Name = "Buon Appеtito", Address = "ул. Орловская 66", Phone = 80293208000, Email = null });
                db.SaveChanges();
            }
        }

        public IEnumerable<Menu> Menus { get; set; }
        public IEnumerable<Organization> Organizations { get; set; }
        public IEnumerable<Dish> Dishes { get; set; }
    }
}