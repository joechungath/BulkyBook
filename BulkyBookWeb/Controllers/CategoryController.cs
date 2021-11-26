using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
    }
}
