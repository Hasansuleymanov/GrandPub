using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
