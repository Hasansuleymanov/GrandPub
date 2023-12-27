using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using WebMVC.Areas.restoranAdmin.Models;

namespace WebMVC.Areas.restoranAdmin.Controllers
{
    [Area(nameof(restoranAdmin))]
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private CategoryServices _categoryService;

        public CategoryController(CategoryServices categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: CategoryController
        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategories());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            Category? selectedCategory = _categoryService.GetByID(id.Value);
            if (selectedCategory == null) return NotFound();

            return View(selectedCategory);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCategoryVM collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Category newCategory = new()
                    {
                        Name = collection.Name,
                        Slug = collection.Slug,
                        IsDefault = collection.IsDefault,
                    };
                    _categoryService.Add(newCategory);

                    return RedirectToAction(nameof(Index));
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_categoryService.GetByID(id));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryService.Update(collection);
                    return RedirectToAction(nameof(Index));
                }
                return View(collection);
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: CategoryController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_categoryService.GetByID(id));
        }

        // POST: CategoryController/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                    Category foundCategory = _categoryService.GetByID(id);
                    _categoryService.Delete(foundCategory);
                    return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
