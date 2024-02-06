using Microsoft.AspNetCore.Mvc;
using Supermarket.Models;
using Supermarket.Data;


namespace Supermarket.Controllers
{
    public class PetController : Controller
    {
        private readonly ApplicationDbCon _db;

        public PetController(ApplicationDbCon db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Pet> objPetCareList = _db.Pet.ToList();
            return View(objPetCareList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pet obj)
        {
            _db.Pet.Add(obj);
            _db.SaveChanges();
            TempData["keymessage"] = "Record Added Successfully. ";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)

        {
            if (id == null || id == 0)
                return NotFound();

            var PetCareFromDb = _db.Pet.Find(id);
            if (PetCareFromDb == null)
                return NotFound();

            return View(PetCareFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Pet obj)
        {
            if (ModelState.IsValid)
            {
                _db.Pet.Update(obj);
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

            var PetCareFromDb = _db.Pet.Find(id);
            if (PetCareFromDb == null)
                return NotFound();

            return View(PetCareFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(Pet obj)
        {
            _db.Pet.Remove(obj);
            _db.SaveChanges();

            TempData["keymessage"] = "Record Deleted Successfully. ";

            return RedirectToAction("Index");

        }

        public IActionResult Details(int? id)

        {
            if (id == null || id == 0)
                return NotFound();

            var PetCareFromDb = _db.Pet.Find(id);
            if (PetCareFromDb == null)
                return NotFound();

            return View(PetCareFromDb);
        }
    }
}
