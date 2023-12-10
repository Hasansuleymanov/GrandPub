using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Areas.restoranAdmin.Controllers
{
    [Area(nameof(restoranAdmin))]
    [Authorize(Roles = "Admin")]

    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
