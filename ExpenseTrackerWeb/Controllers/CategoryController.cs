using ExpenseTrackerWeb.Data;
using ExpenseTrackerWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
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
                    if (_db.Categories.Any(c => c.Name == category.Name))
                    {
                        ModelState.AddModelError("Name", "Category '" + category.Name + "' already exists!");
                        return View(category);
                    }
                    _db.Categories.Add(category);
                    _db.SaveChanges();
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
            Category category = _db.Categories.FirstOrDefault(c => c.Id == id);
            if(category == null)
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
                    if (_db.Categories.Any(c => c.Name == category.Name && c.Id != category.Id))
                    {
                        ModelState.AddModelError("Name", "Category '" + category.Name + "' already exists!");
                        return View(category);
                    }
                    _db.Categories.Update(category);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the category.");
                }

            }
            return View();
        }
    }
}
