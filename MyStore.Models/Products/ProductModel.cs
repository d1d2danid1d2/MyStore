using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class ProductModel   {
        public int Productid { get; set; }
        public string Productname { get; set; }
        public int Supplierid { get; set; }
        public int Categoryid { get; set; }
        public decimal Unitprice { get; set; }
        public bool Discontinued { get; set; }

        public virtual CategoryModel Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetailModel> OrderDetails { get; set; }
    }
}
