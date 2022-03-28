using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class ShipperModel
    {
        public int Shipperid { get; set; }
        [Required]
        public string Companyname { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
