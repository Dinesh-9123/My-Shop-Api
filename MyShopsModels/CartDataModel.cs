using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsModels
{
    public class CartDataModel
    {
        public List<CartModel> items { get; set; }
        public int totalAmount { get; set; }
    }
}
