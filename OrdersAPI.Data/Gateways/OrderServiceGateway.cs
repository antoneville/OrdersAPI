using OrdersAPI.Data.DTO;
using OrdersAPI.Data.Gateways.Interfaces;
using OrdersAPI.Data.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersAPI.Data.Gateways
{
    public class OrderServiceGateway : PersistenceGateway, IOrderServiceGateway
    {
        private readonly string vw_Orders = "[dbo].[vw_AllOrders]";

        private readonly string sp_UpdateOrderStatus = "[dbo].[sp_UpdateOrderStatus]";
        private readonly string sp_UpdateDeliveryAddress = "[dbo].[sp_UpdateDeliveryAddress]";
        private readonly string sp_InsertDeliveryAddress = "[dbo].[sp_InsertDeliveryAddress]";
        private readonly string sp_InsertOrderStatus = "[dbo].[sp_InsertOrderStatus]";
        private readonly string sp_InsertOrder = "[dbo].[sp_InsertOrder]";

        public OrderServiceGateway(string connectionString) : base(connectionString) { }

        public async Task CancelOrder(OrderPersistence order)
        {
            var parameters = DataAssistance.AddParameters(order);
            await Update(sp_UpdateOrderStatus, parameters);
        }

        public async Task CreateOrder(OrderPersistence order)
        {
            var parameters = DataAssistance.AddParameters(order);
            await Insert(sp_InsertOrder, parameters);
        }

        public async Task<IEnumerable<OrderDetailsPersistence>> GetOrders()
        {
            var query = DataAssistance.SQLView(
                new OrderDetailsPersistence(), vw_Orders);

            return await Get<OrderDetailsPersistence>(query);
        }

        public async Task<IEnumerable<OrderDetailsPersistence>> GetPagedOrders()
        {
            var pagingCondition =
                "ORDER BY s.OrderDate" +
                "OFFSET 5 Rows";

            var query = DataAssistance.SQLView(
                new OrderDetailsPersistence(), vw_Orders, pagingCondition);

            return await Get<OrderDetailsPersistence>(query);
        }

        public async Task UpdateDeliveryAddress(DeliveryAddressPersistence address)
        {            
            var parameters = DataAssistance.AddParameters(address);
            await Update(sp_UpdateDeliveryAddress, parameters);
        }

        public Task UpdateOrderedItems(ProductPersistence orderedItems)
        {           
            throw new System.NotImplementedException();
        }
    }
}
