using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace comero.Models
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            CartItems = new List<CartItem>();
        }
        public List<CartItem> CartItems { get; set; }
        public decimal orderTotal { get; set; }
    }
}
