using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.WEB.Models
{
    public class Organization
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }


    }
}