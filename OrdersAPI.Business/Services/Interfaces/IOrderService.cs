using OrdersAPI.Business.Models;
using OrdersAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersAPI.Services.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(Order order);
        Task UpdateDeliveryAddress(DeliveryAddress address);
        Task UpdateOrderedItems(List<Product> orderedItems);
        Task CancelOrder(Order order);
        Task<IEnumerable<OrderDetails>> GetOrders();
        Task<IEnumerable<OrderDetails>> GetPagedOrders();
    }
}
