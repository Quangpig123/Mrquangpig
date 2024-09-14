using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
    public class SanPhamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult TaoSanPham()
        {
            return View(new SanPhamViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> TaoSanPham(SanPhamViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.AnhMoTa != null && model.AnhMoTa.Length > 0)
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", model.AnhMoTa.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.AnhMoTa.CopyToAsync(stream);
                    }
                }
                ViewBag.ThongTinSanPham = $"Tên sản phẩm: {model.TenSanPham}\n" +
                                          $"Giá bán: {model.GiaBan:C}\n" +
                                          $"Ảnh mô tả: {model.AnhMoTa.FileName}";

                return View("ThongTinSanPham", model);
            }

            return View(model);
        }

        public IActionResult ThongTinSanPham(SanPhamViewModel model)
        {
            return View(model);
        }
    }
}
