using MyShopsDomain;
using MyShopsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsServices.Infrastructure.Builders.Interfaces
{
    public interface ICartBuilder
    {
        CartItem Build(MyCartDto cartData);
        MyCartDto Build(CartItem cartData);
    }
}
