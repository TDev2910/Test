using System.Linq;
using Practice_Day2_Mobishop.Models;

namespace Practice_Day2_Mobishop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        // Phương thức tạo đơn hàng
        public void CreateOrder(Order order)
        {
            // Thêm đơn hàng vào database
            _context.Orders.Add(order);

            // Thêm chi tiết đơn hàng
            foreach (var orderDetail in order.OrderDetails)
            {
                _context.OrderDetails.Add(orderDetail);
            }

            // Lưu thay đổi vào database
            _context.SaveChanges();
        }
    }
}
