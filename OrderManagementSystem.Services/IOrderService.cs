using OrderManagementSystem.Models;
using OrderManagementSystem.Models.Dtos;

namespace OrderManagementSystem.Services
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(CreateOrderDto dto);
        Task<Order> UpdateOrderStatusAsync(int orderId, OrderStatus newStatus);
        Task<OrderAnalytics> GetAnalyticsAsync();
        Task<Order> GetOrderByIdAsync(int orderId);
    }
}
