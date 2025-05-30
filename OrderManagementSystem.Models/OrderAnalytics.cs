namespace OrderManagementSystem.Models
{
    public class OrderAnalytics
    {
        public decimal AverageOrderValue { get; set; }
        public decimal AverageFulfillmentTime { get; set; }
        public Dictionary<OrderStatus, int> OrderCountByStatus { get; set; } = new();
        public Dictionary<CustomerSegment, decimal> AverageValueBySegment { get; set; } = new();
    }
}
