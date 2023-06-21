using Microsoft.AspNetCore.Mvc;

namespace StoreApp.Areas.Admin.AddControllersWithViews
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}