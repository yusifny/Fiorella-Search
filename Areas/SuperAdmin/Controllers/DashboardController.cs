using Microsoft.AspNetCore.Mvc;

namespace FrontToBack.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    public class DashboardController : Controller
    {
        // GET
        public IActionResult Index()
        {
             return View();
        }
    }
}