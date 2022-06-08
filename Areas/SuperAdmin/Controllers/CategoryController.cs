using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FrontToBack.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Category dbCategory = await _context.Categories.FindAsync(id);
            if (dbCategory == null) return NotFound();

            return View(dbCategory);
        }

        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            if (id == null) return NotFound();
            Category dbCategory = await _context.Categories.FindAsync(id);
            if (dbCategory == null) return NotFound();
            return View(dbCategory);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();
            Category dbCategory = await _context.Categories.FindAsync(id);
            if (dbCategory == null) return NotFound();
            _context.Categories.Remove(dbCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool isExistName =  _context.Categories.Any(c => c.Name.ToLower() == category.Name.ToLower());
            if (isExistName)
            {
                ModelState.AddModelError("Name", "The category already exist");
                return View();
            }
            Category newCategory = new Category();
            newCategory.Name = category.Name;
            newCategory.Desc = category.Desc;

            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Category dbCategory = await _context.Categories.FindAsync(id);
            if (dbCategory == null) return NotFound(); 
            return View(dbCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Category dbCategory = await _context.Categories.FindAsync(id);
            Category existCategoryName =
                _context.Categories.FirstOrDefault(c => c.Name.ToLower() == category.Name.ToLower());

            if (existCategoryName != null)
            {
                if (dbCategory != existCategoryName)
                {
                    ModelState.AddModelError("Name", "This name already exist");
                    return View();
                }
            }
            
            if (dbCategory == null) return NotFound();
            dbCategory.Name = category.Name;
            dbCategory.Desc = category.Desc;
            await _context.SaveChangesAsync();
            //TempData["message"] = dbCategory.Name + "is successfully updated";
            return RedirectToAction("Detail", "Category", new {@id=id});
        }
        
    }
}