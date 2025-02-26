using Microsoft.AspNetCore.Mvc;
using Practice_Day2_Mobishop.Infrastructure;
using Practice_Day2_Mobishop.Models;
using System.Collections.Generic;
using System.Linq;

public class CartController : Controller
{
    private readonly AppDbContext _db;

    public CartController(AppDbContext db)
    {
        _db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public IActionResult Index()
    {
        var cartItems = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

        // Tạo một đối tượng Cart để truyền vào View
        var cart = new Cart();
        foreach (var item in cartItems)
        {
            cart.AddItem(item.Product, item.Quantity);
        }

        return View(cart);
    }

    [HttpPost]
    public IActionResult AddToCart(int productId)
    {
        var product = _db.Products.FirstOrDefault(p => p.Id == productId);
        if (product == null)
        {
            return NotFound();
        }

        var cartItems = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

        var existingItem = cartItems.FirstOrDefault(p => p.Product.Id == productId);
        if (existingItem != null)
        {
            existingItem.Quantity++;
        }
        else
        {
            cartItems.Add(new CartItem { Product = product, Quantity = 1 });
        }

        HttpContext.Session.SetJson("Cart", cartItems);

        return RedirectToAction("Index", "Cart");
    }
    [HttpPost]
    public IActionResult IncreaseQuantity(int productId)
    {
        var cartItems = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

        var item = cartItems.FirstOrDefault(p => p.Product.Id == productId);
        if (item != null)
        {
            item.Quantity++; // Tăng số lượng
        }

        HttpContext.Session.SetJson("Cart", cartItems);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DecreaseQuantity(int productId)
    {
        var cartItems = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

        var item = cartItems.FirstOrDefault(p => p.Product.Id == productId);
        if (item != null)
        {
            if (item.Quantity > 1)
            {
                item.Quantity--; // Giảm số lượng
            }
            else
            {
                cartItems.Remove(item); // Xóa sản phẩm nếu số lượng = 1
            }
        }

        HttpContext.Session.SetJson("Cart", cartItems);
        return RedirectToAction("Index");
    }
    [HttpGet]
    [HttpPost]
    public IActionResult RemoveItem(int productId)
    {
        var cartItems = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

        var itemToRemove = cartItems.FirstOrDefault(p => p.Product.Id == productId);
        if (itemToRemove != null)
        {
            cartItems.Remove(itemToRemove);
        }

        HttpContext.Session.SetJson("Cart", cartItems);

        return RedirectToAction("Index");
    }

    //Controller xử lý checkout khi thanh toán
    public IActionResult Checkout()
    {
        var cartItems = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

        if (!cartItems.Any())
        {
            return RedirectToAction("Index"); // Nếu giỏ hàng trống, quay lại trang giỏ hàng
        }

        return View(cartItems);
    }
}