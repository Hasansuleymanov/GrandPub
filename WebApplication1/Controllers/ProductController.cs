using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebMVC.Controllers
{
    public class ProductController : Controller
    {

        private readonly ProductServices _productService;

        public ProductController(ProductServices productService)
        {
            _productService = productService;
        }

        public IActionResult Index(string? slug)
        {
            var products = _productService.GetProductsByCategorySlug(slug);

            return View(products);
        }
        public IActionResult Detail(string slug)
        {
                _productService.GetProductsByCategorySlug(slug);
            return View();
        }

        //public PartialViewResult ProductListPartial(int ? categoryId)
        //{
        //    var productList = _productService.GetProductsByCategoryId(categoryId.Value);
        //    ViewBag.categoryId = categoryId;
        //    return PartialView(productList);
        //}
    }
}
