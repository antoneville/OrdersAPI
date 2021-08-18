namespace OrdersAPI.Data.DTO
{
    public class OrderPersistence
    {
        public int ProductID { get; set; }
        public int QuantityOrdered { get; set; }
        public int OrderStatusID { get; set; }
        public int DeliveryAddressID { get; set; }
    }
}
