using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public interface IDiscountService
    {
        decimal CalculateDiscount(Order order, Customer customer);
    }
}
