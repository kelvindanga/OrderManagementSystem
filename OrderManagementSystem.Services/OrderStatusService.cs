using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        private readonly Dictionary<OrderStatus, HashSet<OrderStatus>> _validTransitions = new()
    {
        { OrderStatus.Created, new() { OrderStatus.Processing } },
        { OrderStatus.Processing, new() { OrderStatus.Shipped, OrderStatus.Cancelled } },
        { OrderStatus.Shipped, new() { OrderStatus.Delivered, OrderStatus.Cancelled } }
    };

        public bool CanTransition(Order order, OrderStatus newStatus)
        {
            if (!_validTransitions.TryGetValue(order.Status, out var validToStates))
                return false;

            return validToStates.Contains(newStatus);
        }

        public void UpdateStatus(Order order, OrderStatus newStatus)
        {
            if (!CanTransition(order, newStatus))
                throw new InvalidOperationException($"Cannot transition from {order.Status} to {newStatus}");

            order.Status = newStatus;
            switch (newStatus)
            {
                case OrderStatus.Shipped:
                    order.ShippedDate = DateTime.UtcNow;
                    break;
                case OrderStatus.Delivered:
                    order.DeliveryDate = DateTime.UtcNow;
                    break;
            }
        }
    }
}
