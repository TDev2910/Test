using Practice_Day2_Mobishop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Practice_Day2_Mobishop.Controllers
{
    public class UpdateProductController : Controller
    {
        private readonly AppDbContext _context;

        public UpdateProductController(AppDbContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách sản phẩm
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // Hiển thị form thêm sản phẩm
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý thêm sản phẩm
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // Hiển thị form chỉnh sửa sản phẩm
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Xử lý chỉnh sửa sản phẩm
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // Hiển thị trang xác nhận xóa
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // Xử lý xóa sản phẩm
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product); // Xóa sản phẩm
                _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
            return RedirectToAction("Index"); // Quay lại trang danh sách
        }


        // Hiển thị chi tiết sản phẩm
        [HttpGet]
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