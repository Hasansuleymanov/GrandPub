using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Services;

namespace WebMVC.Areas.restoranAdmin.Controllers
{
    [Area(nameof(restoranAdmin))]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly ProductServices _productService;
        private readonly CategoryServices _categoryService;


        public ProductController(ProductServices productService, CategoryServices categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View(_productService.GetAll());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            Product? selectedProduct = _productService.GetByID(id.Value);
            if (selectedProduct == null) return NotFound();

            return View(selectedProduct);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            // Assuming you have a method to get the list of categories
            var categories = _categoryService.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Size,CategoryId,Price,ThumbnailUrl")] Product product, IFormFile? PhotoUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (PhotoUrl != null && PhotoUrl.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + PhotoUrl.FileName;
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await PhotoUrl.CopyToAsync(stream);
                        }

                        product.ThumbnailUrl = uniqueFileName;
                    }

                    _productService.Add(product);
                    return RedirectToAction(nameof(Index));
                }
                var categories = _categoryService.GetAllCategories();
                ViewBag.Categories = new SelectList(categories, "Id", "Name");

                return View(product);
            }
            catch (Exception ex)
            {
                // Log the exception, handle errors, etc.
                ModelState.AddModelError("", "An error occurred while saving your data.");
                return View(product);
            }
        }

        // Other actions and methods can be added as needed.
        // GET: ProductController/Edit/5
        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productService.GetByID(id);

            if (product == null)
            {
                return NotFound();
            }
            var categories = _categoryService.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return View(product);
        }


        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Size,CategoryId,Price,ThumbnailUrl")] Product product, IFormFile? PhotoUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (PhotoUrl != null && PhotoUrl.Length > 0)
                    {
                        // Handle photo upload similar to the Create action
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + PhotoUrl.FileName;
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await PhotoUrl.CopyToAsync(stream);
                        }

                        product.ThumbnailUrl = uniqueFileName;
                    }

                    _productService.Update(product);
                    return RedirectToAction(nameof(Index));
                }
                var categories = _categoryService.GetAllCategories();
                ViewBag.Categories = new SelectList(categories, "Id", "Name");
                return View(product);
            }
            catch (Exception ex)
            {
                // Log the exception, handle errors, etc.
                ModelState.AddModelError("", "An error occurred while saving your data.");
                return View(product);
            }
        }

        // GET: ProductController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_productService.GetByID(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                Product foundProduct = _productService.GetByID(id);
                _productService.Delete(foundProduct);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
