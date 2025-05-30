using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IEnumerable<IDiscountRule> _discountRules;

        public DiscountService(IEnumerable<IDiscountRule> discountRules)
        {
            _discountRules = discountRules;
        }

        public decimal CalculateDiscount(Order order, Customer customer)
        {
            var totalDiscount = 0m;
            foreach (var rule in _discountRules)
            {
                if (rule.IsApplicable(order, customer))
                {
                    totalDiscount += rule.CalculateDiscount(order, customer);
                }
            }
            return Math.Min(totalDiscount, order.TotalAmount);
        }
    }
}
