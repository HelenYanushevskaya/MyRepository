using Application.DAL.Entities;
using System;

namespace Application.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Dish> Dishes { get; }
        IRepository<Menu> Menus { get; }
        void Save();
    }
}
