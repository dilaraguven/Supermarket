using Microsoft.AspNetCore.Mvc;
using Supermarket.Models;
using Supermarket.Data;

namespace Supermarket.Controllers
{
    public class PersonalCareController : Controller
    {
        private readonly ApplicationDbCon _db;

        public PersonalCareController(ApplicationDbCon db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<PersonalCare> objCareList = _db.PersonalCare.ToList();
            return View(objCareList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PersonalCare obj)
        {
            _db.PersonalCare.Add(obj);
            _db.SaveChanges();
            TempData["keymessage"] = "Record Added Successfully. ";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)

        {
            if (id == null || id == 0)
                return NotFound();

            var CareFromDb = _db.PersonalCare.Find(id);
            if (CareFromDb == null)
                return NotFound();

            return View(CareFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(PersonalCare obj)
        {
            if (ModelState.IsValid)
            {
                _db.PersonalCare.Update(obj);
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

            var CareFromDb = _db.PersonalCare.Find(id);
            if (CareFromDb == null)
                return NotFound();

            return View(CareFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(PersonalCare obj)
        {
            _db.PersonalCare.Remove(obj);
            _db.SaveChanges();

            TempData["keymessage"] = "Record Deleted Successfully. ";

            return RedirectToAction("Index");

        }

        public IActionResult Details(int? id)

        {
            if (id == null || id == 0)
                return NotFound();

            var CareFromDb = _db.PersonalCare.Find(id);
            if (CareFromDb == null)
                return NotFound();

            return View(CareFromDb);
        }
    }
}
