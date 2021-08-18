using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Business.Models;
using OrdersAPI.Models;
using OrdersAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersAPI.Controllers
{
    [Route("Order")]
    [ApiController]
    public class OrdersController : ControllerAPIBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("Order")]
        public async Task<ActionResult> CreateOrder([FromBody] Order order) =>
            await ExecutePost(() => _orderService.CreateOrder(order));

        [HttpPut]
        [Route("DeliveryAddress")]
        public async Task<ActionResult> UpdateDeliveryAddress([FromBody] DeliveryAddress address) =>
            await ExecutePut(() => _orderService.UpdateDeliveryAddress(address));

        [HttpPut]
        [Route("OrderedItems")]
        public async Task<ActionResult> UpdateOrderedItems([FromBody] List<Product> orderedItems) =>
            await ExecutePut(() => _orderService.UpdateOrderedItems(orderedItems));

        [HttpPut]
        [Route("CancelOrder")]
        public async Task<ActionResult> CancelOrder([FromBody] Order order) =>
            await ExecutePut(() => _orderService.CancelOrder(order));

        [HttpGet]
        [Route("Orders")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrders() =>
            await ExecuteGet(() => _orderService.GetOrders());

        [HttpGet]
        [Route("PagedOrders")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetPagedOrders() =>
            await ExecuteGet(() => _orderService.GetPagedOrders());
    }
}