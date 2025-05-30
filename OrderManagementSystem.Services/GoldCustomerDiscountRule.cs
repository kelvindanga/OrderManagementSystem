using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public class GoldCustomerDiscountRule : IDiscountRule
    {
        private const decimal GoldDiscountRate = 0.10m; // 10% discount

        public decimal CalculateDiscount(Order order, Customer customer)
        {
            return order.TotalAmount * GoldDiscountRate;
        }

        public bool IsApplicable(Order order, Customer customer)
        {
            return customer.Segment == CustomerSegment.Gold;
        }
    }
}
