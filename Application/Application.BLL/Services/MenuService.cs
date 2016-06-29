using Application.BLL.DTO;
using Application.BLL.Infrastructure;
using Application.BLL.Interfaces;
using Application.DAL.Entities;
using Application.DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace Application.BLL.Services
{
    public class MenuService : IMenuService
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
            Mapper.CreateMap<Dish, DishDTO>();
            return Mapper.Map<IEnumerable<Dish>, List<DishDTO>>(Database.Dishes.GetAll());
        }

        public void MakeMenu(MenuDTO menuDto)
        {
            Dish dish = Database.Dishes.Get(menuDto.DishId);
           
            // валидация
            if (dish == null)
                throw new ValidationException("блюдо не найдено", "");
            Menu menu = new Menu
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
    }
}
