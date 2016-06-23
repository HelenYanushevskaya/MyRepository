using Application.BLL.BusinessModels;
using Application.BLL.DTO;
using Application.BLL.Infrastructure;
using Application.BLL.Interfaces;
using Application.DAL.Entities;
using Application.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BLL.Services
{
    class MenuService : IMenuService
    {
        IUnitOfWork Database { get; set; }

        public MenuService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public DishDTO GetDish(int? id)
        {

            if (id == null)
                throw new ValidationException("You dont have id", "");
            var dish = Database.Dishes.Get(id.Value);
            if (dish == null)
                throw new ValidationException("Error", "");
            // применяем автомаппер для проекции Dish на DishDTO
            Mapper.CreateMap<Dish, DishDTO>();
            return Mapper.Map<Dish, DishDTO>(dish);
        }

        public IEnumerable<DishDTO> GetDishes()
        {
            Mapper.CreateMap<Dish  , DishDTO>();
            return Mapper.Map<IEnumerable<Dish>, List<DishDTO>>(Database.Dishes.GetAll());
        }

        public OrganizationDTO GetOrganization(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrganizationDTO> GetOrganizations()
        {
            Mapper.CreateMap<Organization, OrganizationDTO>();
            return Mapper.Map<IEnumerable<Organization>, List<OrganizationDTO>>(Database.Organizations.GetAll());
        }

        public void MakeMenu(MenuDTO menuDto)
        {
            Dish dish = Database.Dishes.Get(menuDto.DishId);

            // валидация
            if (dish == null)
                throw new ValidationException("Телефон не найден", "");
            // применяем скидку
            decimal sum = new Converter(dish.Weight).GetConverter(dish.Weight);
            Menu menu = new Menu
            {
                Date = DateTime.Now,
                OrganizationId = 1,
                DishId = 1
            };
            Database.Menus.Create(organization);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
