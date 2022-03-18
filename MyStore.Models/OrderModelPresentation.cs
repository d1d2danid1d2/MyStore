using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MyStore.Models
{
    public class OrderModelPresentation
    {
        public int Orderid { get; set; }
        public int? Custid { get; set; }
        public int Empid { get; set; }
        public string Shipcountry { get; set; }
        public DateTime Orderdate { get; set; }
        public virtual ICollection<OrderDetailModel> OrderDetails { get; set; }
    }
}
