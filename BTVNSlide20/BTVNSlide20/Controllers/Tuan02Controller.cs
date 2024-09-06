using Microsoft.AspNetCore.Mvc;

namespace BTVNSlide20.Controllers
{
    public class Tuan02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Đặng Minh Quang";
            ViewBag.MSSV = "1822040944";
            ViewBag.Nam = DateTime.Now.Year;
            return View();
        }
        public ActionResult MayTinh(int a, int b, string pheptinh)
        {
            double ketqua = 0;

           
            switch (pheptinh)
            {
                case "cong":
                    ketqua = a + b;
                    break;
                case "tru":
                    ketqua = a - b;
                    break;
                case "nhan":
                    ketqua = a * b;
                    break;
                case "chia":
               
                    if (b != 0)
                    {
                        ketqua = (double)a / b;
                    }
                    else
                    {
                        ViewBag.Loi = "Không thể chia cho 0";
                    }
                    break;
                default:
                    ViewBag.Loi = "Phép tính không hợp lệ";
                    break;
            }

         
            if (ViewBag.Loi == null)
            {
                ViewBag.KetQua = ketqua;
            }

            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
    }
}
