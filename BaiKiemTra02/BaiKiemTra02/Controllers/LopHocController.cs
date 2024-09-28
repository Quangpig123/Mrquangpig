using BaiKiemTra02.Data;
using BaiKiemTra02.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra02.Controllers
{
    public class LopHocController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LopHocController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var lophoc = _db.lophoc.ToList();
            ViewBag.lophoc = lophoc;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(LopHoc lophoc)
        {
            if (ModelState.IsValid)
            {
                _db.lophoc.Add(lophoc);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var lophoc = _db.lophoc.Find(id);
            return View(lophoc);
        }
        [HttpPost]

        public IActionResult Edit(LopHoc lophoc)
        {
            if (ModelState.IsValid)
            {
                _db.lophoc.Update(lophoc);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var lophoc = _db.lophoc.Find(id);
            return View(lophoc);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var lophoc = _db.lophoc.Find(id);
            if (lophoc == null)
            {
                return NotFound();
            }
            _db.lophoc.Remove(lophoc);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var lophoc = _db.lophoc.Find(id);

            if (lophoc == null)
            {
                return NotFound();
            }

            return View(lophoc);
        }
        [HttpPost]
        public IActionResult DetailsPost(int id)
        {
            return Forbid();
        }


    }
}
