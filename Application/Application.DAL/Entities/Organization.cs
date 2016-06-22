using System;
using System.Collections.Generic;

namespace Application.DAL.Entities
{
    public class Organization
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }

        public  IEnumerable<Menu> Menus { get; set; }

    }
}