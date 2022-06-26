using FrontToBack.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FrontToBack.Controllers
{
    public class SliderController : Controller
    {
        // GET
        private AppDbContext _context;
        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}