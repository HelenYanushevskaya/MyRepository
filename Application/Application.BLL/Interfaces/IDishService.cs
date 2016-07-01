using Application.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BLL.Interfaces
{
    public interface IDishService 
    {
        void MakeDish (DishDTO dishDto);
        void Dispose();
    }
}
