using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DangKy()
        {
            return View(new TaiKhoanViewModel());
        }

        [HttpPost]
        public IActionResult DangKy(TaiKhoanViewModel model)
        {
            if (ModelState.IsValid)
            {
                string result = $"Tên tài khoản: {model.TenTaiKhoan}\n" +
                                $"Mật khẩu: {model.MatKhau}\n" +
                                $"Họ tên: {model.HoTen}\n" +
                                $"Tuổi: {model.Tuoi}";
                return Content(result, "text/plain");
            }
            return View(model);

        }
    }
}

