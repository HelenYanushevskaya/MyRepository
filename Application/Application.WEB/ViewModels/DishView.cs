﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application.WEB.ViewModels
{
    public class DishView
    {
        public int Id { get; set; }
       // [Required]
        public string Name { get; set; }
       // [Required]
      //  [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Ingredients { get; set; }
       // [Required]
        public int Weight { get; set; }
    }
}