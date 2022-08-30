using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsDomain
{
    [Table("[Users].[UsersCart]")]
    public class CartDto
    {
        [Key]
        public int cartId { get; set; }
        public int userId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string imgUrl { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public int quantity { get; set; }
    }
}
