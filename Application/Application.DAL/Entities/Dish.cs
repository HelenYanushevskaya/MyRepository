using System.Collections.Generic;

namespace Application.DAL.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }

        public int Weight { get; set; }

        public IEnumerable<Menu> Menus { get; set; }

    }
}