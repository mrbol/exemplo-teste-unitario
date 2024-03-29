﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApp.Domain.Common;

namespace TesteApp.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Id = 0;
            Name= String.Empty;
            Barcode= String.Empty;
            Description= String.Empty;
            Rate = 0;
        }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
}
