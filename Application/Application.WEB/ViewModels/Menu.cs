using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application.WEB.ViewModels
{
    public class Menu
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}")]
        public DateTime Date { get; set; }

        public int? DishId { get; set; }
    }
}