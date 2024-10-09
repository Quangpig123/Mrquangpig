using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_04.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal TotalAmount { get; set; }

        [Required]
        public string OrderStatus { get; set; }
    }
}
