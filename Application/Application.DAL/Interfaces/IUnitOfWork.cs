using Application.DAL.Entities;
using System;

namespace Application.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Dish> Dishes { get; }
        IRepository<Organization> Organizations { get; }
        IRepository<Menu> Menus { get; }
        void Save();
    }
}
