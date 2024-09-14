using System.ComponentModel.DataAnnotations;

namespace BaiTapKiemTra01.Models
{
    public class SanPhamViewModel
    {
        [Required(ErrorMessage = "Tên sản phẩm không được để trống.")]
        public string TenSanPham { get; set; }

        [Required(ErrorMessage = "Giá bán không được để trống.")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá bán phải là một số dương.")]
        public decimal GiaBan { get; set; }

        [Required(ErrorMessage = "Ảnh mô tả không được để trống.")]
        public IFormFile AnhMoTa { get; set; }
    }
}
