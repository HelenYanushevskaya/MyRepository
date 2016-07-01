using Application.BLL.DTO;
using Application.BLL.Interfaces;
using Application.DAL.Entities;
using Application.DAL.Interfaces;

namespace Application.BLL.Services
{
    class DishService : IDishService
    {
        IUnitOfWork Database { get; set; }


        public DishService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void MakeDish(DishDTO dishDto)
        {           
            DishEntity dish = new DishEntity
            {
                Name = dishDto.Name,
                Ingredients = dishDto.Ingredients,
                Weight = dishDto.Weight
            };
            Database.Dishes.Create(dish);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
