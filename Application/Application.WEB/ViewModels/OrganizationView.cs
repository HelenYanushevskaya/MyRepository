using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Web.Models
{
    public class OrganizationView
    {
        //[Required]
        public int Id { get; set; }
       // [Required]
        public string Name { get; set; }

        //[Required]
        public string Address { get; set; }

        //[DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        //[RegularExpression(@"^\+[2-9]\d{3}-\d{3}-\d{4}$", ErrorMessage = "The Dish number should be in the format + xxxx-xxx-xxxx")]
        public long Phone { get; set; }
    }
}