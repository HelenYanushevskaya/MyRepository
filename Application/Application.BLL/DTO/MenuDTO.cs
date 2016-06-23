using System;
using System.Collections.Generic;

namespace Application.BLL.DTO

{
    public class MenuDTO
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int? OrganizationId { get; set; }

        public int? DishId { get; set; }

        public virtual DishDTO Dish { get; set; }
    }
}