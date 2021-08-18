using System;

namespace OrdersAPI.Data.DTO
{
    public class OrderDetailsPersistence
    {
        public int OrderID { get; set; }
        public string ProductName { get; set; }
        public int QuantityOrdered { get; set; }
        public int? HouseNumber { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
