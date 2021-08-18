using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersAPI.Business.Models
{
    public class Status
    {
        public int OrderStatusID { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderUpdated { get; set; }
        public DateTime? OrderUpdatedDate { get; set; }
    }
}
