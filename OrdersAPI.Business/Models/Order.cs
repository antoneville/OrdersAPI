using OrdersAPI.Business.Models;
using System;
using System.Collections.Generic;

namespace OrdersAPI.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DeliveryAddress DeliveryAddress { get; set; }
        public Status OrderStatus { get; set; }
        public Product Product { get; set; }
        public int QuantityOrdered { get; set; }
    }
}
