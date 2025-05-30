using OrderManagementSystem.Models.Dtos;

namespace OrderManagementSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount  => TotalAmount - DiscountAmount;
        public OrderStatus Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ShippedDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string? TrackingNumber { get; set; }

        public OrderResponseDto ToDto()
        {
            return new OrderResponseDto
            {
                Id = this.Id,
                CustomerId = this.CustomerId,
                TotalAmount = this.TotalAmount,
                DiscountAmount = this.DiscountAmount,
                FinalAmount = this.FinalAmount,
                Status = this.Status,
                CreatedDate = this.CreatedDate,
                ShippedDate = this.ShippedDate,
                DeliveryDate = this.DeliveryDate,
                TrackingNumber = this.TrackingNumber
            };
        }

    }

}
