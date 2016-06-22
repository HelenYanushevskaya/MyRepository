using Application.DAL.Entities;
using Application.DAL.Interfaces;
using Application.DAL.Models;
using System;
using System.Collections.Generic;


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

        public void Create(Dish book)
        {
            db.Dishes.Add(book);
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
            Dish book = db.Dishes.Find(id);
            if (book != null)
                db.Dishes.Remove(book);
        }
    }
}
