using MyShopsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsServices.Infrastructure.Interfaces
{
    public interface IProductsService
    {
        Task<List<ProductModel>> GetAllProducts();
        Task<int> Add(ProductModel item, int roleId);
        Task<string> Delete(ProductModel item, int roleId);   
        Task<ProductModel> GetById(int id);
    }
}
