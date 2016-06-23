using Application.DAL.Entities;
using Application.DAL.Interfaces;
using Application.DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Application.DAL.Repositories
{
    public class DishRepository : IRepository<Dish>
    {
        private AppContext db;

        public DishRepository(AppContext context)
        {
            this.db = context;
        }

        public IEnumerable<Dish> GetAll()
        {
            return db.Dishes;
        }

        public Dish Get(int id)
        {
            return db.Dishes.Find(id);
        }

        public void Create(Dish item)
        {
            db.Dishes.Add(item);
        }

        public void Update(Dish book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Dish> Find(Func<Dish, Boolean> predicate)
        {
            return db.Dishes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Dish dish = db.Dishes.Find(id);
            if (dish != null)
                db.Dishes.Remove(dish);
        }
    }
}
