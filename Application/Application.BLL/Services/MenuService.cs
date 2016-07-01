using Application.BLL.DTO;
using Application.BLL.Infrastructure;
using Application.BLL.Interfaces;
using Application.DAL.Entities;
using Application.DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System;

namespace Application.BLL.Services
{
    public class MenuService : IMenuService
    {
        private DishRepository dishRepository;
        IUnitOfWork Database { get; set; }

        public MenuService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public DishDTO GetDish(int? id)
        {

           /* if (id == null)
                throw new ValidationException("You dont have id", "");
            var dish = Database.Dishes.Get(id.Value);
            if (dish == null)
                throw new ValidationException("Error", "");*/
           
            var dishId = dishRepository.Get(c => c.Id == id).Id;
            return dishRepository.Get(dishId);

        }

        public IEnumerable<DishDTO> GetDishes()
        {
            // Mapper.CreateMap<DishEntity, DishDTO>();
            // return Mapper.Map<IEnumerable<DishEntity>, List<DishDTO>>(Database.Dishes.GetAll());
            // return null;
            //  Mapper.Map<IEnumerable<Dish>, List<DishDTO>>(Database.Dishes.GetAll());
            var item = dishRepository.GetAll();
            return item;
        }


        public void MakeMenu(MenuDTO menuDto)
        {
            DishEntity dish = Database.Dishes.Get(menuDto.DishId);
           
            // валидация
            if (dish == null)
                throw new ValidationException("блюдо не найдено", "");
            MenuEntity menu = new MenuEntity
            {
                Date = menuDto.Date,
                DishId = menuDto.DishId
            };
            Database.Menus.Create(menu);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public OrganizationDTO GetOrganization(int? id)
        {
            if (id == null)
                throw new ValidationException("You dont have id", "");
            var dish = Database.Organizations.Get(id.Value);
            if (dish == null)
                throw new ValidationException("Error", "");
            //применяем автомаппер для проекции Dish на DishDTO
            Mapper.CreateMap<OrganizationEntity, OrganizationDTO>();
            return Mapper.Map<OrganizationEntity, OrganizationDTO>(dish);
        }

        public IEnumerable<OrganizationDTO> GetOrganizations()
        {
            Mapper.CreateMap<OrganizationEntity, OrganizationDTO>();
            return Mapper.Map<IEnumerable<OrganizationEntity>, List<OrganizationDTO>>(Database.Organizations.GetAll());
        }
    }
}
