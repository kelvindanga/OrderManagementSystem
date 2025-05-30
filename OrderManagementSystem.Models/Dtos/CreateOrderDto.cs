namespace OrderManagementSystem.Models.Dtos
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Notes { get; set; }
    }
}
