using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class EmployeeModel
    {
        public int Empid { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Titleofcourtesy { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public DateTime Hiredate { get; set; }
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
