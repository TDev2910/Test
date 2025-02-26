using Microsoft.AspNetCore.Mvc;
//using Practice_Day2_Mobishop.Data;
//using Practice_Day2_Mobishop.Models;
using System.Linq;
using Practice_Day2_Mobishop.Models;

namespace Practice_Day2_Mobishop.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList(); // Lấy danh sách sản phẩm từ cơ sở dữ liệu
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}