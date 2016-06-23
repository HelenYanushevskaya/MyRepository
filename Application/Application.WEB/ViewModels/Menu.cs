
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.WEB.Models
{
    public class Menu
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}")]
        public DateTime Date { get; set; }

        public int? OrganizationId { get; set; }
        public int? DishId { get; set; }
    }
}