using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web_Lab_Milevskaya_90311.DAL.Data;
using Web_Lab_Milevskaya_90311.DAL.Entities;

namespace Web_Lab_Milevskaya_90311.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Web_Lab_Milevskaya_90311.DAL.Data.ApplicationDbContext _context;

        public IndexModel(Web_Lab_Milevskaya_90311.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dish> Dish { get;set; }

        public async Task OnGetAsync()
        {
            Dish = await _context.Dishes
                .Include(d => d.Group).ToListAsync();
        }
    }
}
