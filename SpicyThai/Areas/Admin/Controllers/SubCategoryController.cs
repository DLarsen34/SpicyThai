using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpicyThai.Data;
using SpicyThai.Models;
using SpicyThai.Models.ViewModels;

namespace SpicyThai.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SubCategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public SubCategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ActionResult> Index()
        {
            var subCategories = await _db.SubCategory.Include(s=>s.Category).ToListAsync();
            return View(subCategories);
        }
        
        //Get Create
        public async Task<IActionResult> Create()
        {
            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = await _db.Category.ToListAsync(),
                SubCategory = new Models.SubCategory(),
                SubCategoryList = await _db.SubCategory.OrderBy(p => p.Name).Select(p => p.Name).Distinct().ToListAsync()
            };

            return View(model);
        }
        //Post Create
        public string statusMessage { get; set; }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubCategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesSubCategoryExist = _db.SubCategory.Include(s => s.Category).Where(s => s.Name == model.SubCategory.Name && s.CategoryId == model.SubCategory.CategoryId);
                if (doesSubCategoryExist.Count() > 0)
                {
                    statusMessage = "Error: SubCategory Exists under " + doesSubCategoryExist.First().Category.Name + " category. Please choose another name.";
                }
                else
                {
                    _db.SubCategory.Add(model.SubCategory);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            //if invlalid (need to retrieve values again and send back to form)

            SubCategoryAndCategoryViewModel modelVM = new SubCategoryAndCategoryViewModel()
            {
                SubCategory = model.SubCategory,
                SubCategoryList = await _db.SubCategory.OrderBy(p => p.Name).Select(p => p.Name).ToListAsync(),
                StatusMessage = statusMessage
            };
            return View(modelVM);
        }
    }
}