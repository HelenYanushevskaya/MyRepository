using System;

namespace Application.DAL.Entities
{
   public  class Menu
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DishId { get; set; }

        public virtual Dish Dish { get; set; }
    }
}
