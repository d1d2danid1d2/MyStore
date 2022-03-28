﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Models
{
    public class CategoryModel
    {
        public int Categoryid { get; set; }
        [Required]
        public string Categoryname { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
