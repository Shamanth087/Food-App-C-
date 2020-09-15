using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_app
{
    public class Item
    {
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public string itemtype { get; set; }


    }

    public class CartItem
    {
        public string name { get; set; }
      
        public double price { get; set; }

        public double quantityPrice { get; set; }

        public int quantity { get; set; }

        public double totalPrice { get; set; }
    }


}
