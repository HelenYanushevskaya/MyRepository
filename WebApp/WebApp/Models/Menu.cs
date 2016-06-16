using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}")]
        public DateTime Date { get; set; }

        public int? OrganizationId { get; set; }

        public int? DishId { get; set; }

        public virtual Dish Dish { get; set; }
        public virtual Organization Organization { get; set; }
    }
}