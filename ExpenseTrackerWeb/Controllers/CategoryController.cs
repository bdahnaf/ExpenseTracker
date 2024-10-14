using ExpenseTrackerWeb.Data;
using ExpenseTrackerWeb.Models;
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.DataAccess.Repository.IRepository;

namespace ExpenseTrackerWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepository.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categoryFromDb = _categoryRepository.Get(c => c.Name == category.Name);
                    if (categoryFromDb != null)
                    {
                        ModelState.AddModelError("Name", "Category '" + category.Name + "' already exists!");
                        return View(category);
                    }
                    _categoryRepository.Add(category);
                    _categoryRepository.Save();
                    TempData["success"] = "Category '" + category.Name + "' saved successfully!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the category.");
                }

            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category category = _categoryRepository.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categoryFromDb = _categoryRepository.Get(c => c.Name == category.Name);
                    if (categoryFromDb != null)
                    {
                        ModelState.AddModelError("Name", "Category '" + category.Name + "' already exists!");
                        return View(category);
                    }
                    _categoryRepository.Update(category);
                    _categoryRepository.Save();
                    TempData["success"] = "Category '" + category.Name + "' updated successfully!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the category.");
                }

            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category category = _categoryRepository.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = _categoryRepository.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryRepository.Remove(category);
            _categoryRepository.Save();
            TempData["success"] = "Category '" + category.Name + "' deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
