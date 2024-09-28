using BaiTap07.Data;
using BaiTap07.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap07.Controllers
{
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TheLoaiController (ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var theloai = _db.TheLoais.ToList();
            ViewBag.theloai = theloai;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                _db.TheLoais.Add(theloai);
                _db.SaveChanges();
               return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id ==0)
            {
                return NotFound();
            }
            var theloai =_db.TheLoais.Find(id);
            return View(theloai);
        }
        [HttpPost]

        public IActionResult Edit(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                _db.TheLoais.Update(theloai);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            var theloai = _db.TheLoais.Find(id);
            return View(theloai);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var theloai = _db.TheLoais.Find(id);
            if(theloai == null)
            {
                return NotFound();
            }
            _db.TheLoais.Remove(theloai);
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
            var theloai = _db.TheLoais.Find(id);
      
            return View(theloai);
        }
        [HttpGet]
        public IActionResult Search(String searchString)
        {
            List<TheLoai> theloai;

            if (!string.IsNullOrEmpty(searchString))
            {
                theloai = _db.TheLoais
                    .Where(tl => tl.Name.Contains(searchString))
                    .ToList();
                ViewBag.SearchString = searchString;
            }
            else
            {
                theloai = _db.TheLoais.ToList();
            }

            
            ViewBag.TheLoai = theloai;

            return View("Index");
        }
        
    }
}
