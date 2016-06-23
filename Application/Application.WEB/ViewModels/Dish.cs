using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.WEB.Models
{
    public class Dish
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Ingredients { get; set; }
        [Required]
        public int Weight { get; set; }
         }
}

