using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontToBack.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Product> products = _context.Products.Include(p => p.Category).Take(8).ToList();
            return View(products);
        }

        public IActionResult LoadMore(int skip)
        {
            List<Product> products = _context.Products.Skip(skip).Take(8).ToList();
            //return View();
            return Json(products);
        }
    }
}
