﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tamiaki.Models
{
    public class ClientProfile
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Serial { get; set; }

    }

    public class Fpa
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }
    public class Product
    {
        public string  Id { get; set; }
        public string BarCode { get; set; } 
        public string Name { get; set; }
        public decimal PriceNetto { get; set; }
        public decimal PriceBrutto { get; set; }
        public string CashRegCategoryId { get; set; }
        public virtual CashRegCategory CashRegCategory { get; set; }

    }
}
