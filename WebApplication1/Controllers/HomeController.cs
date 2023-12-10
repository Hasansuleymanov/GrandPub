using Microsoft.AspNetCore.Mvc;
using Services;
using System.Diagnostics;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MainConfigurationService _configuration;
        private readonly CategoryServices _category; 
        private readonly ProductServices _product;

        public HomeController(ILogger<HomeController> logger, MainConfigurationService configuration, CategoryServices category, ProductServices product)
        {
            _logger = logger;
            _configuration = configuration;
            _category = category;
            _product = product;
        }

        [HttpGet("{slug?}")]
        public IActionResult Index(string? slug="")
        {
            var products = _product.GetProductsByCategorySlug(slug);

            HomeVM vm = new()
            {
                MainConfigurations = _configuration.GetAll(),
                Categories=_category.GetAllCategories(),
                Products=products,
                Slug=slug
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
