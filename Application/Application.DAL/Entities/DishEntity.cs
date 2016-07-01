using System.Collections.Generic;

namespace Application.DAL.Entities
{
    public class DishEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public int Weight { get; set; }

        public virtual ICollection<MenuEntity> Menus { get; set; }
    }
}
