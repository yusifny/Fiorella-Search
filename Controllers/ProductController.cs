using System.Collections.Generic;
using System.Linq;
using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.ProductCount = _context.Products.Count();
            List<Product> products = _context.Products.Include(p => p.Category).Take(8).ToList();
            return View(products);
        }

        public IActionResult LoadMore(int skip)
        {
            List<Product> products = _context.Products.Include(p=> p.Category).Skip(skip).Take(8).ToList();
            return PartialView("_ProductPartial", products);
        }
    }
}
