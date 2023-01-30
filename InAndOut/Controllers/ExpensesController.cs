using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;

namespace InAndOut.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExpensesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _db.Expenses;
            return View(objList);
        }
        // Get Create
        public IActionResult Create()
        {
            return View();
        }

        // Post Create
        [HttpPost] // Allows for form entry (posting)
        [ValidateAntiForgeryToken] // Check if we still have a token, only execute post if we are logged in
        public IActionResult Create(Expense obl)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Add(obl);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obl);
        }

        // Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Post Delete
        [HttpPost] // Allows for form entry (posting)
        [ValidateAntiForgeryToken] // Check if we still have a token, only execute post if we are logged in
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Expenses.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        // Get Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Post Update
        [HttpPost] // Allows for form entry (posting)
        [ValidateAntiForgeryToken] // Check if we still have a token, only execute post if we are logged in
        public IActionResult Update(Expense obl)
        {
            if (ModelState.IsValid)
            {
                _db.Expenses.Update(obl);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obl);
        }
    }
}

