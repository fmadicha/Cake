using CakeWebsite.Data;
using CakeWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CakeWebsite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CakeDbContext _context;
        public CategoryController(CakeDbContext cakeDb)
        {
            _context = cakeDb;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _context.Categories;
            return View(objCategoryList);
        }
        //Get
        public IActionResult Create()
        {

            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]//prevents cross site forgery(its a key)
        public IActionResult Create(Category obj)
        {//check validation
            if (obj.Name == obj.Display.ToString())
            {
                ModelState.AddModelError("CustomError", "The Display can not exactly match the name.");
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)// invalid id
            {
                return NotFound();
            }
            var categoryFromDb = _context.Categories.Find(id);
            // or
            // var category1st= _context.Categories.FirstOrDefault(u=>u.CategoryId==id);
            // var categorySingle = _context.Categories.SingleOrDefault(u => u.CategoryId == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]//prevents cross site forgery(its a key)
        public IActionResult Edit(Category obj)
        {//check validation
            if (obj.Name == obj.Display.ToString())
            {
                ModelState.AddModelError("CustomError", "The Display can not exactly match the name.");
            }
            if (ModelState.IsValid)
            {
                _context.Categories.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)// invalid id
            {
                return NotFound();
            }
            var categoryFromDb = _context.Categories.Find(id);
            // or
            // var category1st= _context.Categories.FirstOrDefault(u=>u.CategoryId==id);
            // var categorySingle = _context.Categories.SingleOrDefault(u => u.CategoryId == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]//prevents cross site forgery(its a key)
        public IActionResult DeletePost(int CategoryId)
        {
            var obj = _context.Categories.Find(CategoryId);
            if (obj == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(obj);
            _context.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");



        }
    }

}