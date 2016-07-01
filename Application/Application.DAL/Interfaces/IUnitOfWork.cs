using Application.DAL.Entities;
using System;

namespace Application.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<DishEntity> Dishes { get; }
        IRepository<MenuEntity> Menus { get; }
        IRepository<OrganizationEntity> Organizations { get; }
        void Save();
    }
}
