using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrdersAPI.Data.Gateways;
using OrdersAPI.Data.Gateways.Interfaces;
using OrdersAPI.Services;
using OrdersAPI.Services.Interfaces;

namespace OrdersAPI.Infrastructure
{
    public class OrdersConnection
    {
        public string ordersDB;
    }

    internal class ConfigureServices
    {
        public static void Configure(IServiceCollection service, IConfiguration config)
        {
            OrdersConnection ordersConnection = new OrdersConnection
            {
                ordersDB = config.GetConnectionString("Orders")
            };

            service.AddTransient<IOrderService, OrderService>();
            service.AddTransient<IOrderServiceGateway>(x => new OrderServiceGateway(ordersConnection.ordersDB));
        }
    }
}
