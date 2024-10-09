using BaiKiemTra03_04.Data;
using BaiKiemTra03_04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_04.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }
         public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Order order)
    {
        if (ModelState.IsValid)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(order);
    }

    // Edit an existing order
    public IActionResult Edit(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null) return NotFound();
        return View(order);
    }

    [HttpPost]
    public IActionResult Edit(Order order)
    {
        if (ModelState.IsValid)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(order);
    }

    // Delete an order
    public IActionResult Delete(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null) return NotFound();
        return View(order);
    }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return Json(new { success = true, message = "Đơn hàng đã được xóa thành công!" });
            }

            return Json(new { success = false, message = "Đơn hàng không tồn tại!" });
        }

        // View order details
        public IActionResult Details(int id)
    {
        var order = _context.Orders.Find(id);
        if (order == null) return NotFound();
        return View(order);
    }
    }
}
