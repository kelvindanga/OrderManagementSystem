
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Models;
using OrderManagementSystem.Services;
using OrderManagementSystem.Data;
using OrderManagementSystem.Models.Dtos;
namespace OrderManagementSystem.Tests
{
    [TestFixture]
    public class OrderServiceTests
    {
        private ApplicationDbContext _context;
        private IOrderService _orderService;
        private IDiscountService _discountService;
        private IOrderStatusService _orderStatusService;

        [SetUp]
        public void Initialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            _discountService = new DiscountService(new List<IDiscountRule>
            {
                new GoldCustomerDiscountRule(),
                new OrderHistoryDiscountRule()
            });
            _orderStatusService = new OrderStatusService();
            _orderService = new OrderService(_context, _discountService, _orderStatusService);
        }

        [TearDown]
        public void Cleanup()
        {
            _context?.Dispose();
        }

        [Test]
        public async Task CreateOrder_ShouldApplyCorrectDiscount()
        {
            // Arrange
            var customer = new Customer
            {
                Id = 1,
                Segment = CustomerSegment.Gold
            };
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            var dto = new CreateOrderDto
            {
                CustomerId = 1,
                TotalAmount = 100m
            };

            // Act
            var order = await _orderService.CreateOrderAsync(dto);

            // Assert
            Assert.That(order, Is.Not.Null);
            Assert.That(order.TotalAmount, Is.EqualTo(100m));
            Assert.That(order.DiscountAmount, Is.EqualTo(10m));
            Assert.That(order.FinalAmount, Is.EqualTo(90m));
            Assert.That(order.Status, Is.EqualTo(OrderStatus.Created));
        }
    }
}