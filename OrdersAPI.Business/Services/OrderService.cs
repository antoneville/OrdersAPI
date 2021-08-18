using AutoMapper;
using OrdersAPI.Business.Models;
using OrdersAPI.Business.Services.BaseServices;
using OrdersAPI.Data.DTO;
using OrdersAPI.Data.Gateways.Interfaces;
using OrdersAPI.Models;
using OrdersAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersAPI.Services
{
    public class OrderService : ServiceBase, IOrderService
    {
        public readonly IOrderServiceGateway _orderServiceGateway;
        public OrderService(IOrderServiceGateway orderServiceGateway, IMapper mapper)
        {
            _orderServiceGateway = orderServiceGateway;
            _mapper = mapper;
        }

        public async Task CancelOrder(Order order)
        {
            await _orderServiceGateway.CancelOrder(_mapper.Map<OrderPersistence>(order));
        }

        public async Task CreateOrder(Order order)
        {
            await _orderServiceGateway.CreateOrder(_mapper.Map<OrderPersistence>(order));
        }

        public async Task<IEnumerable<OrderDetails>> GetOrders()
        {
            var orders = await _orderServiceGateway.GetOrders();
            _logger.Information("Gathering all of the Orders.");

            return _mapper.Map<IEnumerable<OrderDetailsPersistence>, IEnumerable<OrderDetails>>(orders);
        }

        public async Task<IEnumerable<OrderDetails>> GetPagedOrders()
        {
            var orders = await _orderServiceGateway.GetPagedOrders();

            return _mapper.Map<IEnumerable<OrderDetailsPersistence>, IEnumerable<OrderDetails>>(orders);
        }

        public async Task UpdateDeliveryAddress(DeliveryAddress address)
        {
            if(IsDeliveryAddressValid(address))
            {
                try
                {
                    await _orderServiceGateway.UpdateDeliveryAddress(_mapper.Map<DeliveryAddressPersistence>(address));
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Updating Delivery Address has failed for AddressID: {AddressID}", address.DeliveryAddressID);
                }
            }
            else _logger.Information("Delivery Address for AddressID: {AddressID} was not valid.", address.DeliveryAddressID);
        }
        
        public async Task UpdateOrderedItems(List<Product> orderedItems)
        {
            foreach(var item in orderedItems)
            {
                if (item == null)
                    throw new ArgumentNullException();

                await _orderServiceGateway.UpdateOrderedItems(_mapper.Map<ProductPersistence>(item));
            }
        }
    }
}
