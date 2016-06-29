using Application.DAL.EF;
using Application.DAL.Entities;
using Application.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DAL.Repositories
{
    public class MenuRepository : IRepository<Menu>
    {
        private AppContext db;

        public MenuRepository(AppContext context)
        {
            this.db = context;
        }

        public IEnumerable<Menu> GetAll()
        {
            return db.Menus.Include(o => o.Dish);
        }

        public Menu Get(int id)
        {
            return db.Menus.Find(id);
        }

        public void Create(Menu item)
        {
            db.Menus.Add(item);
        }

        public void Update(Menu item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Menu> Find(Func<Menu, Boolean> predicate)
        {
            return db.Menus.Include(o => o.Dish).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Menu menu = db.Menus.Find(id);
            if (menu != null)
                db.Menus.Remove(menu);
        }
    }
}
