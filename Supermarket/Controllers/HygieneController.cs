using Microsoft.AspNetCore.Mvc;
using Supermarket.Models;
using Supermarket.Data;

namespace Supermarket.Controllers
{
    public class HygieneController : Controller
    {
        private readonly ApplicationDbCon _db;

        public HygieneController(ApplicationDbCon db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Hygiene> objHygieneList = _db.Hygiene.ToList();
            return View(objHygieneList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Hygiene obj)
        {
            _db.Hygiene.Add(obj);
            _db.SaveChanges();
            TempData["keymessage"] = "Record Added Successfully. ";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)

        {
            if (id == null || id == 0)
                return NotFound();

            var HygieneFromDb = _db.Hygiene.Find(id);
            if (HygieneFromDb == null)
                return NotFound();

            return View(HygieneFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Hygiene obj)
        {
            if (ModelState.IsValid)
            {
                _db.Hygiene.Update(obj);
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

            var HygieneFromDb = _db.Hygiene.Find(id);
            if (HygieneFromDb == null)
                return NotFound();

            return View(HygieneFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(Hygiene obj)
        {
            _db.Hygiene.Remove(obj);
            _db.SaveChanges();

            TempData["keymessage"] = "Record Deleted Successfully. ";

            return RedirectToAction("Index");

        }

        public IActionResult Details(int? id)

        {
            if (id == null || id == 0)
                return NotFound();

            var HygieneFromDb = _db.Hygiene.Find(id);
            if (HygieneFromDb == null)
                return NotFound();

            return View(HygieneFromDb);
        }
    }
}
