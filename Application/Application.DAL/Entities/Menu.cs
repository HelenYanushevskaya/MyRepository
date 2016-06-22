using System;
using System.Collections.Generic;

namespace Application.DAL.Entities
{
    public class Menu
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int? OrganizationId { get; set; }

        public int? DishId { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Organization Organization { get; set; }
    }
}