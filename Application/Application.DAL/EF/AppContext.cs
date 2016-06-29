using Application.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DAL.EF
{
    public class AppContext:DbContext
    {

        //передача строки подключения
        public AppContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            Database.SetInitializer(new StoreDbInitializer());
        }


        //инициализация данных
        public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<AppContext>
        {
            protected override void Seed(AppContext db)
            {
                db.Dishes.Add(new Dish { Name = "Курица «Пикассо»", Ingredients = "Курица Сладкий перец Соль Черный перец", Weight = 220 });
                db.Dishes.Add(new Dish { Name = "Азу по‑татарски", Ingredients = "Говядина Лук сооленые огурцы Соль Черный перец", Weight = 220 });
        
                db.SaveChanges();
            }
        }


        //?
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Dish> Dishes { get; set; }

    }
}
