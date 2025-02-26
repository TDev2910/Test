using Microsoft.AspNetCore.Mvc;
using Practice_Day2_Mobishop.Models;
using System.Linq;
using System.Collections.Generic;

public class ListProductController : Controller
{
    private readonly AppDbContext _db;

    public ListProductController(AppDbContext db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public IActionResult Index(string os = null, string priceRange = null, string searchTerm = null)
    {
        // Lấy danh sách hệ điều hành từ database
        ViewBag.OSOptions = _db.Products.Select(p => p.OS).Distinct().ToList();

        // Gán giá trị đã chọn để giữ trạng thái UI
        ViewBag.SelectedOS = os;
        ViewBag.SelectedPriceRange = priceRange;
        ViewBag.SearchTerm = searchTerm;

        // Lấy danh sách sản phẩm
        var products = _db.Products.AsQueryable();

        // Lọc theo hệ điều hành nếu có
        if (!string.IsNullOrEmpty(os))
        {
            products = products.Where(p => p.OS.ToLower() == os.ToLower());
        }

        // Lọc theo khoảng giá
        if (!string.IsNullOrEmpty(priceRange))
        {
            switch (priceRange)
            {
                case "10-15":
                    products = products.Where(p => p.Price >= 10000000 && p.Price <= 15000000);
                    break;
                case "15-30":
                    products = products.Where(p => p.Price > 15000000 && p.Price <= 30000000);
                    break;
                case "30-50":
                    products = products.Where(p => p.Price > 30000000 && p.Price <= 50000000);
                    break;
            }
        }

        // Tìm kiếm theo tên sản phẩm
        if (!string.IsNullOrEmpty(searchTerm))
        {
            products = products.Where(p => p.Name.ToLower().Contains(searchTerm.ToLower()));
        }

        // Trả về danh sách sản phẩm sau khi lọc
        return View(products.ToList());
    }
}