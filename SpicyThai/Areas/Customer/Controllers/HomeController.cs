using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpicyThai.Data;
using SpicyThai.Models;
using SpicyThai.Models.ViewModels;

namespace SpicyThai.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Area("Customer")]
        public async Task<IActionResult> Index()
        {
            IndexViewModel IndexViewModel = new IndexViewModel()
            {
                MenuItem = await _db.MenuItem
                                    .Include(m => m.Category)
                                    .Include(s => s.SubCategory)
                                    .ToListAsync(),
                Coupon = await _db.Coupon
                                  .Where(c=>c.IsActive)
                                  .ToListAsync(),
                Category = await _db.Category.ToListAsync()
            };
            return View(IndexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
