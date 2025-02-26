using Microsoft.AspNetCore.Mvc;
using Practice_Day2_Mobishop.Infrastructure;
using Practice_Day2_Mobishop.Models;
using Practice_Day2_Mobishop.Repositories;

namespace Practice_Day2_Mobishop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: Order/Checkout
        public IActionResult Checkout()
        {
            return View();
        }

        // POST: Order/Checkout
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View(order);
            }

            var cartItems = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            if (!cartItems.Any())
            {
                ModelState.AddModelError("", "Giỏ hàng trống!");
                return View(order);
            }

            order.OrderDetails = cartItems.Select(item => new OrderDetail
            {
                ProductId = item.Product.Id,
                Quantity = item.Quantity,
                Price = item.Product.Price
            }).ToList();

            _orderRepository.CreateOrder(order);

            HttpContext.Session.Remove("Cart"); // Xóa giỏ hàng sau khi đặt hàng

            return RedirectToAction("Completed");
        }

        public IActionResult Completed()
        {
            return View();
        }
    }
}
