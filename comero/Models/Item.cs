using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace comero.Models
{
    public class Item
    {
        public int Id { get; set; }
      
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }

        // navigation
        public Product Product { get; set; }
    }
}
