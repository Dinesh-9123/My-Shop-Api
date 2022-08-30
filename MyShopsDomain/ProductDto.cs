using Dapper.Contrib.Extensions;

namespace MyShopsDomain
{
    [Table("[Products].[MealsProducts]")]
    public class ProductDto
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string imgUrl { get; set; }
        public int price { get; set; }
        public string description { get; set; }
    }
}