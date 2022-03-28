using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class ProductModel{
        public int Productid { get; set; }
        [Required]
        public string Productname { get; set; }
        [Required]
        public int Supplierid { get; set; }
        [Required]
        public int Categoryid { get; set; }
        [Required]
        public decimal Unitprice { get; set; }
        [Required]
        public bool Discontinued { get; set; }

        public virtual CategoryModel Category { get; set; }
        public virtual ShipperModel Supplier { get; set; }
        public virtual ICollection<OrderDetailModel> OrderDetails { get; set; }
    }
}
