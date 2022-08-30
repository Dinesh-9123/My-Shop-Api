using AutoMapper;
using MyShopsDomain;
using MyShopsModels;
using MyShopsServices.Infrastructure.Builders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopsServices.Infrastructure.Builders
{
    public class CartBuilder : ICartBuilder
    {
        private readonly IMapper _mapper;
        public CartBuilder(IMapper mapper)
        {
            _mapper = mapper;
        }
        public CartItem Build(MyCartDto cartData)
        {
            return _mapper.Map<CartItem>(cartData);
        }

        public MyCartDto Build(CartItem cartData)
        {
            return _mapper.Map<MyCartDto>(cartData);  
        }
    }
}
