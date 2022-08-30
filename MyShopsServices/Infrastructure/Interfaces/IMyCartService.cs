using MyShopsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsServices.Infrastructure.Interfaces
{
    public interface IMyCartService
    {
        Task<CartDataModel> GetAll(int userId);
        Task<string> RemoveItem(CartItem cartItem);
        Task<string> AddItem(CartItem cartItem);
    }
}
