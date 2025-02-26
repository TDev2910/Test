using Microsoft.AspNetCore.Mvc;
using Practice_Day2_Mobishop.Models;

public class PlaceOrderController : Controller
{
    // Hiển thị trang PlaceOrder
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    // Xử lý đơn hàng sau khi người dùng gửi form
    [HttpPost]
    public IActionResult Index(List<CartItem> cartItems)
    {
        if (cartItems != null && cartItems.Any())
        {
            // Xử lý đơn hàng (có thể lưu vào cơ sở dữ liệu hoặc gọi API thanh toán)
            // Ví dụ, chuyển tiếp dữ liệu để xác nhận đơn hàng

            return RedirectToAction("ConfirmOrder");
        }

        // Nếu giỏ hàng trống hoặc có lỗi, quay lại trang PlaceOrder
        return View();
    }

    [HttpGet]
    public IActionResult ConfirmOrder()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ConfirmOrder(OrderModel order)
    {
        if (ModelState.IsValid)
        {
            // Tiến hành xử lý đơn hàng và thanh toán

            return RedirectToAction("OrderSuccess");
        }

        return View("Index");
    }
}