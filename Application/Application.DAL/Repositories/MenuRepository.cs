using Application.DAL.Entities;
using Application.DAL.Interfaces;
using Application.DAL.Models;
using System;
using System.Collections.Generic;


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
            return db.Menus;
        }

        public Menu Get(int id)
        {
            return db.Menus.Find(id);
        }

        public void Create(Menu book)
        {
            db.Menus.Add(book);
        }

        public void Update(Menu book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Menu> Find(Func<Menu, Boolean> predicate)
        {
            return db.Menus.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Menu book = db.Menus.Find(id);
            if (book != null)
                db.Menus.Remove(book);
        }
    }
}
