using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext dbContext)
        {
            _db=dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categorylist = _db.Categories;
            return View(categorylist);
        }
        //Get
        public IActionResult Create()
        {
            
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Displayorder cannot be Same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                TempData["Success"] = "Category created successfully";

                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(category);
            

        }

        //Get
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var catfromDB = _db.Categories.Find(Id);
            if (catfromDB == null)
            {
                return NotFound();
            }
            return View(catfromDB);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Displayorder cannot be Same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                TempData["Success"] = "Category Updated successfully";
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);


        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var catfromDB = _db.Categories.Find(Id);
            if (catfromDB == null)
            {
                return NotFound();
            }
            return View(catfromDB);
        }
        //post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            //if (category.Name == category.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name", "Name and Displayorder cannot be Same");
            //}
            var obj = _db.Categories.Find(Id);
                _db.Categories.Remove(obj);
            TempData["Success"] = "Category Deleted successfully";
            _db.SaveChanges();
                return RedirectToAction("Index");
           



        }
    }
}
