using Application.DAL.EF;
using Application.DAL.Entities;
using Application.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DAL.Repositories
{
    //взаимодействие с базой данных
    public class EFUnitOfWork : IDisposable, IUnitOfWork
    {
        private AppContext db;

        private DishRepository dishRepository;
       private MenuRepository menuRepository;

        public EFUnitOfWork(string connnectionString)
        {
            db = new AppContext(connnectionString);
        }

        public IRepository<Dish> Dishes
        {
            get
            {
                if (dishRepository == null)
                    dishRepository = new DishRepository(db);
                return dishRepository;
            }
        }

        public IRepository<Menu> Menus
        {
            get
            {
                if (menuRepository == null)
                    menuRepository = new MenuRepository(db);
                return menuRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
