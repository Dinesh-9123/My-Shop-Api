using MyShopsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsData.Interfaces
{
    public interface IProductRepository : IRepository<ProductDto>
    {
        Task<ProductDto> GetById(int id);
    }
}
