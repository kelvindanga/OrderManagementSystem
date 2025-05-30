using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Services;
using OrderManagementSystem.Models.Dtos;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        
        [HttpPost]
        [ProducesResponseType(typeof(OrderResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderResponseDto>> CreateOrder([FromBody] CreateOrderDto dto)
        {
            var order = await _orderService.CreateOrderAsync(dto);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order.ToDto());
        }

        
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderResponseDto>> GetOrder(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();
            return order.ToDto();
        }

        
        [HttpPut("{id}/status")]
        [ProducesResponseType(typeof(OrderResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<OrderResponseDto>> UpdateOrderStatus(int id, [FromBody] UpdateOrderStatusDto dto)
        {
            var order = await _orderService.UpdateOrderStatusAsync(id, dto.Status);

            return Ok(order.ToDto());
        }

       
        [HttpGet("analytics")]
        [ProducesResponseType(typeof(OrderAnalytics), StatusCodes.Status200OK)]
        public async Task<ActionResult<OrderAnalytics>> GetAnalytics()
        {
            var analytics = await _orderService.GetAnalyticsAsync();
            return Ok(analytics);
        }
    }
}
