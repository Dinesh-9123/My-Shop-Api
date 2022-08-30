using MyShopsDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsData.Interfaces
{
    public interface IMyCartRepository: IRepository<MyCartDto>
    {
        Task<List<CartDto>> GetByUserId(int userId);
        Task<string> UpdateItem(int userId, int id, int quantity);
        Task<CartDto> GetByUserIDAndItemId(int userId, int id);
        Task<string> AddItem(MyCartDto item);
        Task<string> DeleteItem(int userId, int id);
    }
}
