using System.ComponentModel.DataAnnotations;

namespace Practice_Day2_Mobishop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [Range(0,100000000,ErrorMessage = "Giá sản phẩm không được quá 100 triệu")]
        public decimal Price { get; set; }
        public decimal? OriginalPrice { get; set; } // Giá gốc (có thể null)
        [Range(1,100,ErrorMessage = "Số lượng sản phẩm phải từ 1 đến 100")]
        public int Stock { get; set; } // Số lượng sản phẩm hiện có
        public int TotalStock { get; set; } // Tổng số lượng sản phẩm
        public string Image { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string DetailedDescription { get; set; } = string.Empty;
        public string Screen { get; set; } = string.Empty;
        public string OS { get; set; } = string.Empty;
        public string Camera { get; set; } = string.Empty;
        public string RAM { get; set; } = string.Empty;
        public string Storage { get; set; } = string.Empty;
        public string Warranty { get; set; } = string.Empty;
    }
}
