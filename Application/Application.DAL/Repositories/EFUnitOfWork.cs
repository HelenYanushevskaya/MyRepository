using Application.DAL.Interfaces;
using System;
using Application.DAL.Entities;
using Application.DAL.EF;

namespace Application.DAL.Repositories
{
    //взаимодействовать с базой данных
    public class EFUnitOfWork : IDisposable, IUnitOfWork
    {
        private AppContext db;

        private DishRepository dishRepository;
        private OrganizationRepository organizationRepository;
        private MenuRepository menuRepository;

        public EFUnitOfWork(string connnectionString)
        {
            db = new AppContext(connnectionString);
        }

        public IRepository<DishEntity> Dishes
        {
            get
            {
                if (dishRepository == null)
                    dishRepository = new DishRepository(db);
                return dishRepository;
            }
        }

        public IRepository<OrganizationEntity> Organizations
        {
            get
            {
                if (organizationRepository == null)
                    organizationRepository = new OrganizationRepository(db);
                return organizationRepository;
            }
        }

        public IRepository<MenuEntity> Menus
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
