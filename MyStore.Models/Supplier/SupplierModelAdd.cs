using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class SupplierModelAdd
    {
        public int Supplierid { get; set; }
        [Required]
        public string Companyname { get; set; }
        [Required]
        public string Contactname { get; set; }
        [Required]
        public string Contacttitle { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
