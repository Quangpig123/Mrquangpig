using BaiKiemTra03_04.Data;
using Microsoft.AspNetCore.Mvc;
using BaiKiemTra03_04.Models;
namespace BaiKiemTra03_04.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SupplierController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var suppliers = _context.Suppliers.ToList();
            return View(suppliers);
        }
        public IActionResult Upsert(int? id)
        {
            Supplier supplier = new Supplier();

            // Nếu có id (chỉnh sửa hoặc xem chi tiết)
            if (id.HasValue)
            {
                supplier = _context.Suppliers.FirstOrDefault(s => s.SupplierId == id.Value);
                if (supplier == null)
                {
                    return NotFound();
                }
            }

            // Nếu không có id, trả về form rỗng để thêm mới
            return View(supplier);
        }

        // POST: Supplier/Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                // Nếu không có SupplierId, thêm mới
                if (supplier.SupplierId == 0)
                {
                    _context.Suppliers.Add(supplier);
                }
                else
                {
                    // Nếu có SupplierId, cập nhật thông tin
                    _context.Suppliers.Update(supplier);
                }

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Nếu thông tin không hợp lệ, trả lại form hiện tại
            return View(supplier);
        }
    }
}
