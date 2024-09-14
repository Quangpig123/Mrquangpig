using System.ComponentModel.DataAnnotations;

namespace BaiTapKiemTra01.Models
{
    public class TaiKhoanViewModel
    {
        
            [Required(ErrorMessage = "Tên tài khoản là bắt buộc.")]
            public string TenTaiKhoan { get; set; }

            [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
            [DataType(DataType.Password)]
            public string MatKhau { get; set; }

            [Required(ErrorMessage = "Họ tên là bắt buộc.")]
            public string HoTen { get; set; }

            [Required(ErrorMessage = "Tuổi là bắt buộc.")]
            [Range(1, 120, ErrorMessage = "Tuổi phải nằm trong khoảng từ 1 đến 120.")]
            public int Tuoi { get; set; }
      


    }
}
