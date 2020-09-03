using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Lab_Milevskaya_90311.DAL.Entities;

namespace Web_Lab_Milevskaya_90311.Controllers
{
    public class ProductController : Controller
    {
        List<Dish> _dishes; 
        List<DishGroup> _dishGroups;
        public ProductController()
        {
            SetupData();
        }

        public IActionResult Index()
        {
            return View(_dishes);
        }


        /// <summary> 
        /// Инициализация списков 
        /// </summary> 
        private void SetupData()
        {
            _dishGroups = new List<DishGroup>
            {
                new DishGroup {DishGroupId=1, GroupName="Салаты"},
                new DishGroup {DishGroupId=2, GroupName="Супы"},
                new DishGroup {DishGroupId=3, GroupName="Основные блюда"},
                new DishGroup {DishGroupId=4, GroupName="Десерты"}
            };

            _dishes = new List<Dish>
            {
                new Dish
                {
                    DishId = 1,
                    DishName = "Фруктовая тарелка",
                    Description = "Большая тарелка с ягодами",
                    Calories = 200,
                    DishGroupId = 4,
                    Image = "222.png"
                },
                new Dish
                {
                    DishId = 2,
                    DishName = "Блины",
                    Description = "С ягодами, без сметаны",
                    Calories = 330,
                    DishGroupId = 3,
                    Image = "333.png"
                },
                new Dish
                {
                    DishId = 3,
                    DishName = "Мороженое",
                    Description = "Мороженое - 80%, фрукты и ягоды - 20%",
                    Calories = 635,
                    DishGroupId = 4,
                    Image = "444.png"
                },
                new Dish
                {
                    DishId = 4,
                    DishName = "Стейк из свинины",
                    Description = "Запеченый на гриле",
                    Calories = 524,
                    DishGroupId = 3,
                    Image = "555.png"
                },
                new Dish
                {
                    DishId = 5,
                    DishName = "Фруктово-овощная нарезка",
                    Description = "Сметана в качестве соуса",
                    Calories = 180,
                    DishGroupId = 1,
                    Image = "666.png"
                }
            };
        }
    }
}