using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public class OrderHistoryDiscountRule : IDiscountRule
    {
        private const decimal RepeatCustomerDiscountRate = 0.05m; 

        public decimal CalculateDiscount(Order order, Customer customer)
        {
            return order.TotalAmount * RepeatCustomerDiscountRate;
        }

        public bool IsApplicable(Order order, Customer customer)
        {
            return customer.Orders.Count > 1;
        }
    }
}
