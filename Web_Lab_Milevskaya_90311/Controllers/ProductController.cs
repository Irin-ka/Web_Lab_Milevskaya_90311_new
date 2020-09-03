using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Web_Lab_Milevskaya_90311.DAL.Entities;
using Web_Lab_Milevskaya_90311.Models;

namespace Web_Lab_Milevskaya_90311.Controllers
{
    public class ProductController : Controller
    {
        public List<Dish> _dishes; 
        List<DishGroup> _dishGroups;
        int _pageSize;
        public ProductController()
        {
            _pageSize = 3;
            SetupData();
        }

        public IActionResult Index(int? group, int pageNo= 1)
        {
            var dishesFiltered = _dishes
            .Where(d => !group.HasValue || d.DishGroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _dishGroups;

            // Получить id текущей группы и поместить в TempData 
            ViewData["CurrentGroup"] = group ?? 0;
            return View(ListViewModel<Dish>.GetModel(dishesFiltered, pageNo,
            _pageSize));
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