using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models;
using OrderManagementSystem.Models.Dtos;

namespace OrderManagementSystem.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IDiscountService _discountService;
        private readonly IOrderStatusService _orderStatusService;

        public OrderService(ApplicationDbContext context,
            IDiscountService discountService,
            IOrderStatusService orderStatusService)
        {
            _context = context;
            _discountService = discountService;
            _orderStatusService = orderStatusService;
        }

        public async Task<Order> CreateOrderAsync(CreateOrderDto dto)
        {
            var customer = await _context.Customers.FindAsync(dto.CustomerId);
            if (customer == null)
                throw new InvalidOperationException("Customer not found");

            var order = new Order
            {
                CustomerId = dto.CustomerId,
                TotalAmount = dto.TotalAmount,
                CreatedDate = DateTime.UtcNow,
                Status = OrderStatus.Created
            };

            order.DiscountAmount = _discountService.CalculateDiscount(order, customer);

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateOrderStatusAsync(int orderId, OrderStatus newStatus)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order == null)
                throw new InvalidOperationException("Order not found");

            _orderStatusService.UpdateStatus(order, newStatus);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<OrderAnalytics> GetAnalyticsAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.Customer)
                .ToListAsync();

            var analytics = new OrderAnalytics
            {
                AverageOrderValue = orders.Average(o => o.FinalAmount),
                AverageFulfillmentTime = (decimal)orders
                    .Where(o => o.Status == OrderStatus.Delivered && o.DeliveryDate.HasValue)
                    .Select(o => (o.DeliveryDate.Value - o.CreatedDate).TotalHours)
                    .DefaultIfEmpty(0)
                    .Average(),
                OrderCountByStatus = orders
                    .GroupBy(o => o.Status)
                    .ToDictionary(g => g.Key, g => g.Count()),
                AverageValueBySegment = orders
                    .GroupBy(o => o.Customer.Segment)
                    .ToDictionary(g => g.Key, g => g.Average(o =>o.FinalAmount))
            };

            return analytics;
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .FirstAsync(o => o.Id == orderId);  
        }
    }
}
