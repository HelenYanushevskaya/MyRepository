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
    public class MenuRepository : IRepository<MenuEntity>
    {
        private AppContext db;

        public MenuRepository(AppContext context)
        {
            this.db = context;
        }

        public IEnumerable<MenuEntity> GetAll()
        {
            return db.Menus.Include(o => o.Dish).Include(o => o.Organization);
        }

        public MenuEntity Get(int id)
        {
            return db.Menus.Find(id);
        }

        public void Create(MenuEntity item)
        {
            db.Menus.Add(item);
        }

        public void Update(MenuEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<MenuEntity> Find(Func<MenuEntity, Boolean> predicate)
        {
            return db.Menus.Include(o => o.Dish).Include(o => o.Organization).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            MenuEntity menu = db.Menus.Find(id);
            if (menu != null)
                db.Menus.Remove(menu);
        }
    }
}
