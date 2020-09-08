using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Web_Lab_Milevskaya_90311.DAL.Data;
using Web_Lab_Milevskaya_90311.DAL.Entities;
using Web_Lab_Milevskaya_90311.Extensions;
using Web_Lab_Milevskaya_90311.Models;

namespace Web_Lab_Milevskaya_90311.Controllers
{
    public class ProductController : Controller
    {
        //public List<Dish> _dishes;
        //List<DishGroup> _dishGroups;
        ApplicationDbContext _context;
        int _pageSize;
        public ProductController(ApplicationDbContext context)
        {
            _pageSize = 3;
             //SetupData();
            _context = context;
        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo= 1)
        {
            var dishesFiltered = _context.Dishes
            .Where(d => !group.HasValue || d.DishGroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.DishGroups;

            // Получить id текущей группы и поместить в TempData 
            ViewData["CurrentGroup"] = group ?? 0;

            var model = ListViewModel<Dish>.GetModel(dishesFiltered, pageNo,_pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_listpartial", model);
            else
                return View(model);

            //return View(ListViewModel<Dish>.GetModel(dishesFiltered, pageNo,
            //_pageSize));
        }


        /// <summary> 
        /// Инициализация списков 
        /// </summary> 
        //private void SetupData()
        //{
        //    _dishGroups = new List<DishGroup>
        //        {
        //            new DishGroup {DishGroupId=1, GroupName="Салаты"},
        //            new DishGroup {DishGroupId=2, GroupName="Супы"},
        //            new DishGroup {DishGroupId=3, GroupName="Основные блюда"},
        //            new DishGroup {DishGroupId=4, GroupName="Десерты"}
        //        };

        //    _dishes = new List<Dish>
        //        {
        //            new Dish
        //            {
        //                DishId = 1,
        //                DishName = "Фруктовая тарелка",
        //                Description = "Большая тарелка с ягодами",
        //                Calories = 200,
        //                DishGroupId = 4,
        //                Image = "121.png"
        //            },
        //            new Dish
        //            {
        //                DishId = 2,
        //                DishName = "Блины",
        //                Description = "С ягодами, без сметаны",
        //                Calories = 330,
        //                DishGroupId = 3,
        //                Image = "131.png"
        //            },
        //            new Dish
        //            {
        //                DishId = 3,
        //                DishName = "Мороженое",
        //                Description = "Мороженое - 80%, фрукты и ягоды - 20%",
        //                Calories = 635,
        //                DishGroupId = 4,
        //                Image = "141.png"
        //            },
        //            new Dish
        //            {
        //                DishId = 4,
        //                DishName = "Стейк из свинины",
        //                Description = "Запеченый на гриле",
        //                Calories = 524,
        //                DishGroupId = 3,
        //                Image = "151.png"
        //            },
        //            new Dish
        //            {
        //                DishId = 5,
        //                DishName = "Фруктово-овощная нарезка",
        //                Description = "В комплексе сметанный соус",
        //                Calories = 180,
        //                DishGroupId = 1,
        //                Image = "161.png"
        //            }
        //        };
        //}
    }
}