namespace OrdersAPI.Models
{
    public class DeliveryAddress
    {
        public int DeliveryAddressID { get; set; }
        public int? HouseNumber { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string Town { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }
}
