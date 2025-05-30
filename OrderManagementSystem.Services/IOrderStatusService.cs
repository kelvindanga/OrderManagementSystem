using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public interface IOrderStatusService
    {
        bool CanTransition(Order order, OrderStatus newStatus);
        void UpdateStatus(Order order, OrderStatus newStatus);
    }
}
