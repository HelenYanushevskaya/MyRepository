using System;

namespace Application.DAL.Entities
{
   public  class MenuEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int OrganizationId { get; set; }
        public int DishId { get; set; }

        public virtual DishEntity Dish { get; set; }
        public virtual OrganizationEntity Organization { get; set; }
    }
}
