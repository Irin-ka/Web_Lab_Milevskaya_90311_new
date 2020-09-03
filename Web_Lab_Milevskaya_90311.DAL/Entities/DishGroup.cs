﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Web_Lab_Milevskaya_90311.DAL.Entities
{
    public class DishGroup
    {
        public int DishGroupId { get; set; }
        public string GroupName { get; set; }
        /// <summary> 
        /// Навигационное свойство 1-ко-многим 
        /// </summary> 
        public List<Dish> Dishes
        { get; set; }

    }
}
