using OrdersAPI.Data.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersAPI.Data.Gateways.Interfaces
{
    public interface IOrderServiceGateway
    {
        Task<IEnumerable<OrderDetailsPersistence>> GetOrders();
        Task UpdateDeliveryAddress(DeliveryAddressPersistence address);
        Task UpdateOrderedItems(ProductPersistence orderedItems);
        Task CancelOrder(OrderPersistence order);
        Task CreateOrder(OrderPersistence order);
        Task<IEnumerable<OrderDetailsPersistence>> GetPagedOrders();
    }
}
