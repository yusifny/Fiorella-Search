using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack.ViewComponents
{
    public class ProductsViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductsViewComponent(AppDbContext context)
        {
            _context = context; 
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Product> products = _context.Products.Include(p => p.Category).Take(8).ToList();
            return View(await Task.FromResult(products));
        }
    }
}