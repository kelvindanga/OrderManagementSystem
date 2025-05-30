using OrderManagementSystem.Models.Dtos;

namespace OrderManagementSystem.Models.Mappers
{
    public static class OrderMapper
    {
        public static OrderResponseDto ToDto(this Order order)
        {
            return new OrderResponseDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                TotalAmount = order.TotalAmount,
                DiscountAmount = order.DiscountAmount,
                FinalAmount = order.FinalAmount,
                Status = order.Status,
                CreatedDate = order.CreatedDate,
                ShippedDate = order.ShippedDate,
                DeliveryDate = order.DeliveryDate,
                TrackingNumber = order.TrackingNumber
            };
        }
    }
}
