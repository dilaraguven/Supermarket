using Microsoft.AspNetCore.Mvc;
using Supermarket.Models;
using Supermarket.Data;
using Microsoft.EntityFrameworkCore;


namespace Supermarket.Controllers
{
    public class SnackController : Controller
    {

        private readonly ApplicationDbCon _db;

        public SnackController(ApplicationDbCon db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Snack> objSnackList = _db.Snacks.ToList();
            return View(objSnackList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Snack obj)
        {
            _db.Snacks.Add(obj);
            _db.SaveChanges();
            TempData["keymessage"] = "Record Added Successfully. ";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)

        {
            if (id == null || id == 0)
                return NotFound();

            var SnackFromDb = _db.Snacks.Find(id);
            if (SnackFromDb == null)
                return NotFound();

            return View(SnackFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Snack obj)
        {
            if (ModelState.IsValid)
            {
                _db.Snacks.Update(obj);
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

            var SnackFromDb = _db.Snacks.Find(id);
            if (SnackFromDb == null)
                return NotFound();

            return View(SnackFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(Snack obj)
        {
            _db.Snacks.Remove(obj);
            _db.SaveChanges();

            TempData["keymessage"] = "Record Deleted Successfully. ";

            return RedirectToAction("Index");

        }

        public IActionResult Details(int? id)

        {
            if (id == null || id == 0)
                return NotFound();

            var SnackFromDb = _db.Snacks.Find(id);
            if (SnackFromDb == null)
                return NotFound();

            return View(SnackFromDb);
        }

    }
}
