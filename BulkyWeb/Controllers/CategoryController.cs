
using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;


namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;
        public CategoryController(AppDbContext db)
        {
            _db = db;


        }
        public IActionResult Index()
        {
            List<Category> objCategoryList=_db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Creat() 
        {
            return View();
        }

        [HttpPost]
		public IActionResult Creat(Category obj)
		{
            if(obj.Name== obj.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError("Name", "The DisplayOrder Cannot be the same as Name.");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
				TempData["success"] = "Category Created Successfully";
				return RedirectToAction("Index");
			}
            return View();
            

		}

		public IActionResult Edit(int? id)
		{
            if (id == null || id == 0) 
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.Categories.FirstOrDefault(i=>i.Id==id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
		}

		[HttpPost]
		public IActionResult Edit(Category obj)
		{
			if (ModelState.IsValid)
			{
				_db.Categories.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Category Updated Successfully";
				return RedirectToAction("Index");
			}
			return View();


		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? categoryFromDb = _db.Categories.FirstOrDefault(i => i.Id == id);
			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}

		[HttpPost,ActionName("Delete")]
		
		public IActionResult DeletePost(int? id)
		{
			Category? obj = _db.Categories.FirstOrDefault(o=>o.Id==id);
			if (obj == null) 
			{
				return NotFound();
			}
			_db.Categories.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Category Deleted Successfully";
			return RedirectToAction("Index");
			
			


		}
	}
}
