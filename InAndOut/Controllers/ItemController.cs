using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;

namespace InAndOut.Controllers
{
    public class ItemController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
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
        public IActionResult Create(Item obl)
        {
            _db.Items.Add(obl);
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
            var obj = _db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Post Update
        [HttpPost] // Allows for form entry (posting)
        [ValidateAntiForgeryToken] // Check if we still have a token, only execute post if we are logged in
        public IActionResult Update(Item obl)
        {
            if (ModelState.IsValid)
            {
                _db.Items.Update(obl);
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
            var obj = _db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Post Update
        [HttpPost] // Allows for form entry (posting)
        [ValidateAntiForgeryToken] // Check if we still have a token, only execute post if we are logged in
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Items.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Items.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
