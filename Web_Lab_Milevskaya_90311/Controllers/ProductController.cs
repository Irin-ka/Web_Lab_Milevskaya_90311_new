using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private ILogger _logger;
        ApplicationDbContext _context;
        int _pageSize;
        public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)
        {
            _pageSize = 3;
             _context = context;
            _logger = logger;
        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo)
        {
            var groupMame = group.HasValue
            ? _context.DishGroups.Find(group.Value)?.GroupName:"all groups";
            _logger.LogInformation($"info: group={group},  page={pageNo}");

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

           
        }


       
    }
}