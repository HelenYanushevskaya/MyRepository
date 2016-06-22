using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.WEB.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "{0:dd'.'MMM'.'yyyy}")]
        public DateTime Date { get; set; }

        [Required]
        public int? OrganizationId { get; set; }

        [Required]
        public int? DishId { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Organization Organization { get; set; }
    }
}