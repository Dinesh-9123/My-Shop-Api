using MyShopsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsData.Interfaces
{
    public interface ICartRepository : IRepository<CartDto>
    {
        Task<List<CartDto>> GetByUserId(int userId); 
        Task<CartDto> GetByUserIDAndItemId(int userId, int id);
        Task<string> AddItem(CartDto item);
        Task<string> UpdateItem(int userId, int id, int quantity);
        Task<string> DeleteItem(int userId , int id);
    }
}
