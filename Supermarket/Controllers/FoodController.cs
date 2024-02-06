 using Microsoft.AspNetCore.Mvc;
using Supermarket.Models;
using Supermarket.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Supermarket.Controllers
{
    public class FoodController : Controller
    {
        private readonly ApplicationDbCon _db;
     

        public FoodController(ApplicationDbCon db)
        {
            _db = db;
        }
       
        public IActionResult Index()
        {
            IEnumerable<Food> objFoodList = _db.Foods.ToList();
            return View(objFoodList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Food obj)
        {
            _db.Foods.Add(obj);
            _db.SaveChanges();
            TempData["keymessage"] = "Record Added Successfully. ";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)

        {
            if (id == null || id == 0)
                return NotFound();

            var FoodFromDb = _db.Foods.Find(id);
            if (FoodFromDb == null)
                return NotFound();

            return View(FoodFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Food obj)
        {
            if (ModelState.IsValid)
            {
                _db.Foods.Update(obj);
                _db.SaveChanges();
                TempData["keymessage"] = "Record Updated Successfully. ";
                return RedirectToAction("Index");
            }
          return View(obj);
        }

        public IActionResult Delete(int? id)

        {
            if (id == null || id == 0)
                return NotFound();

            var FoodFromDb = _db.Foods.Find(id);
            if (FoodFromDb == null)
                return NotFound();

            return View(FoodFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(Food obj)
        {
            _db.Foods.Remove(obj);
            _db.SaveChanges();

            TempData["keymessage"] = "Record Deleted Successfully. ";

            return RedirectToAction("Index");

        }

        public IActionResult Details(int? id)

        {
            if (id == null || id == 0)
                return NotFound();

            var FoodFromDb = _db.Foods.Find(id);
            if (FoodFromDb == null)
                return NotFound();

            return View(FoodFromDb);
        }


    }
}
