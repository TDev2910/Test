using System.ComponentModel.DataAnnotations;

namespace Practice_Day2_Mobishop.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
