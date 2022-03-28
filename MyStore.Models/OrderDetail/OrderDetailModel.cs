using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class OrderDetailModel
    {
        public int Orderid { get; set; }
        [Required]
        public int Productid { get; set; }
        [Required]
        public decimal Unitprice { get; set; }
        [Required]
        public short Qty { get; set; }
        [Required]
        public decimal Discount { get; set; }

    }
}
