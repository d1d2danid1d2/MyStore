using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class OrderModel
    {
        public int Orderid { get; set; }
        
        [Required]
        public int? Custid { get; set; }
        [Required]
        public int Empid { get; set; }
        [Required]
        public int Shipperid { get; set; }
        [Required]
        public string Shipname { get; set; }
        [Required]
        public string Shipcountry { get; set; }
        [Required]
        public string Shipcity { get; set; }
        [Required]
        public string Shipaddress { get; set; }
        [Required]
        public decimal Freight { get; set; }
        [Required]
        public DateTime Orderdate { get; set; }
        [Required]
        public DateTime Requireddate { get; set; }

        public virtual ICollection<OrderDetailModel> OrderDetails { get; set; }
    }
}
