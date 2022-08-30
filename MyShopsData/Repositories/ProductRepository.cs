using Dapper;
using MyShopsData.Interfaces;
using MyShopsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsData.Repositories
{
    public class ProductRepository : BaseRepository<ProductDto>, IProductRepository
    {
        public ProductRepository(IDatabaseFactory databaseFactory) 
            : base(databaseFactory)
        {
        }

        public async Task<ProductDto> GetById(int id)
        {
            var res = await DataContext.QueryAsync<ProductDto>($"SELECT * FROM [Products].[MealsProducts] WHERE id = {id}");
            return res.FirstOrDefault();
        }
    }
}
