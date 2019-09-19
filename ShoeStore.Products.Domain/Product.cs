﻿using System;
using System.Collections.Generic;

namespace ShoeStore.Products.Domain
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public int Rank { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public decimal Cost { get; set; }

        public int Stock { get; set; }

        public List<CatalogueProduct> CatalogueProducts { get; set; }
    }
}