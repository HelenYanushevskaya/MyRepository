﻿using Application.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BLL.Interfaces
{
    public interface IMenuService
    {
        void MakeMenu(MenuDTO menuDto);
        DishDTO GetDish(int? id);
        IEnumerable<DishDTO> GetDishes();
        void Dispose();
    }
}