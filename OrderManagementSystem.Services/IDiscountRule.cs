using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public interface IDiscountRule
    {
        decimal CalculateDiscount(Order order, Customer customer);
        bool IsApplicable(Order order, Customer customer);
    }
}
