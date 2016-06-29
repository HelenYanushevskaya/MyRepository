using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BLL.DTO
{
    public class MenuDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int OrganizationId { get; set; }
        public int DishId { get; set; }
    }
}
