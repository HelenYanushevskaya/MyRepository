using Application.DAL.EF;
using Application.DAL.Entities;
using Application.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

public class DishRepository : IRepository<DishEntity>
{
    private AppContext db;
    private IDbSet<DishEntity> dbset;

    public DishRepository(AppContext context)
    {
        this.db = context;
    }

    /* public IEnumerable<DishEntity> GetAll()
     {
         return db.Dishes;
     }*/

    public DishEntity Get(Expression<Func<DishEntity, bool>> where)
    {
        return dbset.Where(where).FirstOrDefault<T>();
    }
     
    /* public DishEntity Get(int id)
     {
         return db.Dishes.Find(id);
     }*/

    public void Create(DishEntity item)
    {
        db.Dishes.Add(item);
    }

    public void Update(DishEntity item)
    {
        db.Entry(item).State = EntityState.Modified;
    }

    public IEnumerable<DishEntity> Find(Func<DishEntity, Boolean> predicate)
    {
        return db.Dishes.Where(predicate).ToList();
    }

    public void Delete(int id)
    {
        DishEntity dish = db.Dishes.Find(id);
        if (dish != null)
            db.Dishes.Remove(dish);
    }
}
